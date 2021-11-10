using System.Collections.Generic;
using UnityEngine;

//Контроллер отряда героев (Не путать с контроллером одного героя!)

public class SquadController : IController
{
    public SquadController()
    {
        squad = new Squad();
        trine = new List<Hero>();

        //подписываемся на событие "приобретен герой"
        EventManager.OnHeroPurchased += DistributeHero;
        //подписываемся на событие "выход из состояния"
        EventManager.OnStageExit += OnStageExit;
    }

    /// <summary>
    /// Отряд
    /// </summary>
    readonly Squad squad;

    /// <summary>
    /// Три одинаковых героя для слияния
    /// </summary>
    List<Hero> trine;

    /// <summary>
    /// Определяет купленного гороя в резерв или во временное хранилище
    /// </summary>
    void AddHero(Hero hero)
    {
        //если есть место в резерве
        if (squad.heroesInReserve.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя в резерв
            squad.heroesInReserve.Add(hero);
            //оповещаем об изменении количества героев в резерве
            EventManager.OnSomethingChangedEventInvoke(squad.heroesInReserve.Count, Changeable.Reserve);
        }
        //если герой не помещается в резерве, проверяем, есть ли место во временном хранилище
        else if (squad.temporaryStorage.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя во временное хранилище
            squad.temporaryStorage.Add(hero);
            //оповещаем об изменении количества героев в хранилище
            EventManager.OnSomethingChangedEventInvoke(squad.temporaryStorage.Count, Changeable.Storage);
        }
        else
        {
            //продаем героя по его "закупочной" стоимости
        }
    }

    /// <summary>
    /// Решает, что делать с купленным героем
    /// </summary>
    /// <param name="obj"></param>
    private void DistributeHero(string heroName)
    {
        //находим в бд нужного героя
        GameObject hero = SelectHeroFromDB(heroName);
        //присваиваем герою ID (и сразу увеличиваем счетчик)
        hero.GetComponent<Hero>().ID = squad.LastID++;
        //проверяем, есть ли у игрока еще два таких же героя
        if (!ThereAreThree(hero))
        {
            //если нет, добавляем героя в отряд
            AddHero(hero.GetComponent<Hero>());
        }
    }

    /// <summary>
    /// Возвращает из бд героя по имени
    /// </summary>
    /// <returns></returns>
    private GameObject SelectHeroFromDB(string heroName)
    {
        foreach (var item in Resources.LoadAll("TestObjects/Heroes") as GameObject[])
        {
            if (item.GetComponent<Hero>().Info.Name == heroName)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// Проверяет, имеется ли у игрока три одинаковых героя
    /// </summary>
    private bool ThereAreThree(GameObject heroGO)
    {
        //добавляем в трин
        trine.Add(heroGO.GetComponent<Hero>());
        //если есть еще два таких же на поле, мерджим
        if (FindTheSame(squad.heroesOnTheField)) return true;
        //иначе продолжаем поиск в резерве
        else if (FindTheSame(squad.heroesInReserve)) return true;
        //иначе очищаем трин
        trine.Clear();
        return false;
    }

    /// <summary>
    /// Ищет одинаковых героев в коллекции
    /// Добавляет их в трин
    /// </summary>
    private bool FindTheSame(List<Hero> heroesList)
    {
        foreach (var item in heroesList)
        {
            if (item.Info.Name == trine[0].Info.Name && item.Info.Rank == trine[0].Info.Rank)
            {
                trine.Add(item);
                if (trine.Count == 3)
                {
                    Merge();
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Производит слияние трех героев
    /// </summary>
    private void Merge()
    {
        //герой, которого будем улучшать
        Hero newHero = trine[0];
        //стоимость экипировки
        int equipmentCost = trine[0].Inventory.EquipmentСost;
        //выбираем героя, который экипирован богаче
        foreach (var item in trine)
        {
            if (item.Inventory.EquipmentСost > equipmentCost)
            {
                equipmentCost = item.Inventory.EquipmentСost;
                newHero = item;
            }
        }
        //если герои не экипированы
        if (equipmentCost == 0)
        {
            //выбираем героя, который стоит на поле
            foreach (var item in trine)
            {
                if (true)
                {

                }
            }
        }


        //создаем временный "рюкзак" для хранения всего, что было надето на героях
        List<Item> backpack = new List<Item>();
        //снимаем с героев все, что на них надето, и складываем в "рюкзак"
        foreach (var item in trine)
        {
            backpack.AddRange(item.Inventory.TakeOffAllItems());
        }

        //улучшаем выбранного героя
        newHero.Raise();

        //удаляем двух оставшихся героев
        foreach (var item in trine)
        {
            if (item.ID != newHero.ID)
            {
                //пробуем удалить с поля
                if (squad.RemoveHeroFromList(item, squad.heroesOnTheField))
                {
                    EventManager.OnSomethingChangedEventInvoke(squad.heroesOnTheField.Count, Changeable.Field);
                }
                //если герой не нашелся на поле, значит он был в резерве
                //удаляем оттуда
                else if (squad.RemoveHeroFromList(item, squad.heroesInReserve))
                {
                    EventManager.OnSomethingChangedEventInvoke(squad.heroesInReserve.Count, Changeable.Reserve);
                }
            }
        }
    }

    public void OnStart()
    {

    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    private void OnStageExit(IStage stage)
    {

        if (stage is PlanningStage)
        {
            TransferHeroesToBattle();
        }
    }

    /// <summary>
    /// Переносит всех героев из коллекции "на поле" в коллекцию "в бою"
    /// </summary>
    private void TransferHeroesToBattle()
    {
        foreach (var item in squad.heroesOnTheField)
        {
            squad.AddHeroToList(item, squad.heroesInBattle);
        }
        squad.heroesInBattle.Clear();
    }

    public void OnExit()
    {
        EventManager.OnHeroPurchased -= DistributeHero;
        EventManager.OnStageExit -= OnStageExit;
    }

    /// <summary>
    /// Изменяет максимальное количество героев на поле
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeMaxHeroesAmount(int experience, int leadership)
    {
        squad.MaxHeroesOnTheFieldAmount = leadership;
    }


}
