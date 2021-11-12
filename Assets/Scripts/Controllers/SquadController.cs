using System.Collections.Generic;
using UnityEngine;

//Контроллер отряда героев

public class SquadController : IController
{
    public SquadController(Field field)
    {
        this.field = field;
        squad = new Squad();
        merger = new Merger(squad);

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
    /// Класс, производящий слияние (повышение ранга)
    /// </summary>
    Merger merger;

    /// <summary>
    /// Поле
    /// </summary>
    private Field field;

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
        if (!merger.ThereAreThree(hero))
        {
            //если нет, добавляем героя в отряд
            AddHero(hero);
        }
    }

    /// <summary>
    /// Определяет купленного героя в резерв или во временное хранилище
    /// </summary>
    void AddHero(GameObject hero)
    {
        //если есть место в резерве
        if (squad.heroesInReserve.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя в резерв
            AddToReserve(hero);
        }
        //если герой не помещается в резерве, проверяем, есть ли место во временном хранилище
        else if (squad.temporaryStorage.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя во временное хранилище
            AddToTemporaryStorage(hero);
        }
        else
        {
            //продаем героя по его "закупочной" стоимости
        }
    }

    /// <summary>
    /// Добавляет героя во временное хранилище
    /// </summary>
    /// <param name="hero"></param>
    private void AddToTemporaryStorage(GameObject hero)
    {
        squad.temporaryStorage.Add(hero.GetComponent<Hero>());
        //оповещаем об изменении количества героев в хранилище
        EventManager.OnSomethingChangedEventInvoke(squad.temporaryStorage.Count, Changeable.Storage);
    }

    /// <summary>
    /// Добавляет героя в резерв
    /// </summary>
    private void AddToReserve(GameObject hero)
    {
        //спавним героя и запоминаем его 
        squad.heroesInReserve.Add(UtilsManager.Spawn(hero, FindFreePointInReserve()).GetComponent<Hero>());
        //оповещаем об изменении количества героев в резерве
        EventManager.OnSomethingChangedEventInvoke(squad.heroesInReserve.Count, Changeable.Reserve);
    }

    /// <summary>
    /// Находит свободную ячейку в резерве
    /// </summary>
    /// <returns></returns>
    private Vector3 FindFreePointInReserve()
    {
        foreach (var item in field.GetReservePoints())
        {
            //если на этой точке никто не стоит
            if (item.ChildrenCharacter == null)
            {
                return item.transform.position;
            }
        }

        return new Vector3();
    }

    /// <summary>
    /// Возвращает из бд героя по имени
    /// </summary>
    /// <returns></returns>
    private GameObject SelectHeroFromDB(string heroName)
    {
        Object[] heroes = Resources.LoadAll("TestObjects/Heroes");
        foreach (var item in heroes)
        {
            if ((item as GameObject).GetComponent<Hero>().Info.Name == heroName)
            {
                return item as GameObject;
            }
        }
        return null;
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
