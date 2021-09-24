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

    /// <summary>
    /// Отряд
    /// </summary>
    Squad squad;

    /// <summary>
    /// Изменяет максимальное количество героев в отряде
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeMaxHeroesAmount(int amount)
    {
        squad.MaxHeroesAmount = amount;
    }

    /// <summary>
    /// Добавляет героя в отряд (если есть место)
    /// </summary>
    void AddHero(Hero hero)
    {
        //если есть место в отряде
        if (squad.heroesInPlanning.Count < squad.MaxHeroesAmount)
        {
            //присваиваем герою ID (и сразу увеличиваем счетчик)
            hero.ID = squad.LastID++;
            //добавляем героя в отряд
            squad.heroesInPlanning.Add(hero);
            //оповещаем об изменении размера отряда
            EventManager.SquadSizeChanged(squad.heroesInPlanning.Count);
        }
    }

    /// <summary>
    /// Удаляет героя из отряда по его ID
    /// </summary>
    /// <param name="heroID"></param>
    bool RemoveHero(int heroID)
    {
        foreach (var item in squad.heroesInPlanning)
        {
            if (item.ID == heroID)
            {
                squad.heroesInPlanning.Remove(item);
                //оповещаем об изменении размера отряда
                EventManager.SquadSizeChanged(squad.heroesInPlanning.Count);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Решает, что делать с купленным героем
    /// </summary>
    /// <param name="obj"></param>
    private void DistributeHero(Hero hero)
    {
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
        List<Hero> trine = new List<Hero>();
        foreach (var item in squad.heroesInPlanning)
        {
            if (item.Name == hero.Name)
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
        Hero newHero = null;

        //проверим, стоит ли хотя бы один из сливаемых героев на поле (или они все в резерве)
        foreach (var item in squad.heroesInPlanning)
        {
            if (item.Status == HeroStatus.OnTheField)
            {
                newHero = item;
                break;
            }
        }

        //если ни один из сливаемых героев не стоит на поле
        if (newHero == null)
        {
            //то улучшать будем того, которого купили раньше других (а в коллекцию мы его добавляли вторым)
            newHero = trine[1];
        }

        //улучшаем выбранного героя
        newHero.Rank++;

        //удаляем двух оставшихся героев
        foreach (var item in squad.heroesInPlanning)
        {
            if (item.ID != newHero.ID)
            {
                squad.heroesInPlanning.Remove(item);
            }
        }
    }

    private void OnDestroy()
    {
        EventManager.OnLeadershipChanged -= ChangeMaxHeroesAmount;
        EventManager.OnHeroPurchased -= DistributeHero;
    }
}
