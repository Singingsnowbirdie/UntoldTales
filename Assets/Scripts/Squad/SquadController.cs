using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Контроллер отряда героев (Не путать с контроллером одного героя!)

public class SquadController : Controller
{
    public override void Initialize()
    {
        base.Initialize();

        squad = new Squad();

        //подписываемся на повышение уровня лидерства
        EventManager.OnLeadershipChanged += ChangeMaxHeroesAmount;
        //подписываемся на событие "куплен герой"
        EventManager.OnHeroPurchased += DistributeHero;
    }

    private void OnDestroy()
    {
        EventManager.OnLeadershipChanged -= ChangeMaxHeroesAmount;
        EventManager.OnHeroPurchased -= DistributeHero;
    }

    /// <summary>
    /// Отряд
    /// </summary>
    Squad squad;

    /// <summary>
    /// Изменяет максимальное количество героев на поле
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeMaxHeroesAmount(int amount)
    {
        squad.MaxHeroesOnTheFieldAmount = amount;
    }

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
            //меняем статус героя
            hero.Status = HeroStatus.InTheReserve;
            //оповещаем об изменении количества героев в резерве
            EventManager.ReserveSizeChanged(squad.heroesInReserve.Count);
        }
        //если герой не помещается в резерве, проверяем, есть ли место во временном хранилище
        else if (squad.temporaryStorage.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя во временное хранилище
            squad.heroesInReserve.Add(hero);
            //оповещаем об изменении количества героев в хранилище
            EventManager.TemporaryStorageSizeChanged(squad.temporaryStorage.Count);
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
    private void DistributeHero(Hero hero)
    {
        //присваиваем герою ID (и сразу увеличиваем счетчик)
        hero.ID = squad.LastID++;
        //проверяем, есть ли у игрока еще два таких же героя
        //если нет, добавляем героя в отряд
        if (!ThereAreThree(hero))
        {
            AddHero(hero);
        }
    }

    /// <summary>
    /// Проверяет, имеется ли у игрока три одинаковых героя
    /// </summary>
    private bool ThereAreThree(Hero hero)
    {
        //коллекция одинаковых героев
        List<Hero> trine = new List<Hero>();

        //добавляем в коллекцию только что купленного героя
        trine.Add(hero);

        //ищем таких же героев на поле
        foreach (var item in squad.heroesOnTheField)
        {
            if (item.Name == hero.Name && item.Rank == hero.Rank)
            {
                trine.Add(item);
                if (trine.Count == 3)
                {
                    Merge(trine);
                    return true;
                }
            }
        }
        //затем ищем таких же героев в резерве
        foreach (var item in squad.heroesInReserve)
        {
            if (item.Name == hero.Name && item.Rank == hero.Rank)
            {
                trine.Add(item);
                if (trine.Count == 3)
                {
                    Merge(trine);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Производит слияние трех героев
    /// </summary>
    private void Merge(List<Hero> trine)
    {
        //герой, которого будем улучшать
        Hero newHero;

        //Проверяем, какой из ранее купленных героев экипирован "богаче".
        //Если такой есть, то улучшать будем его.
        //Проверяем только первого и второго героев, потому что "нулевой", это тот, которого мы только что купили.
        //Само собой, на нем ничего неще не надето, и он не размещен на поле
        if (trine[1].EquipmentСost > trine[2].EquipmentСost)
        {
            newHero = trine[1];
        }
        else if (trine[2].EquipmentСost > trine[1].EquipmentСost)
        {
            newHero = trine[2];
        }
        //если оба героя экипированы равными (по суммарной стоимости) предметами, или не экипированы вообще
        else
        {
            //если второй герой выставлен на поле, то будем улучшать его
            if (trine[2].Status == HeroStatus.OnTheField)
            {
                newHero = trine[2];
            }
            //иначе будем улучшать первого героя
            else
            {
                newHero = trine[1];
            }
        }

        //создаем временный "рюкзак" для хранения всего, что было надето на героях
        List<Item> backpack = new List<Item>();
        //снимаем с героев все, что на них надето, и складываем в "рюкзак"
        foreach (var item in trine)
        {
            backpack.AddRange(item.TakeOffAllItems());
        }

        //улучшаем выбранного героя
        newHero.Raise();

        //удаляем двух оставшихся героев
        foreach (var item in trine)
        {
            if (item.ID != newHero.ID)
            {
                if (item.Status == HeroStatus.OnTheField)
                {
                    squad.RemoveHeroFromField(item);
                }
                else if (item.Status == HeroStatus.InTheReserve)
                {
                    squad.RemoveHeroFromReserve(item);
                }
            }
        }
    }

}
