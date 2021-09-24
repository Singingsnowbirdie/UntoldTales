using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Контроллер отряда героев (Не путать с контроллером одного героя!)

public class SquadController : Controller
{
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
        if (squad.heroes.Count < squad.MaxHeroesAmount)
        {
            //присваиваем герою ID (и сразу увеличиваем счетчик)
            hero.HeroID = squad.LastID++;
            //добавляем героя в отряд
            squad.heroes.Add(hero);
            //оповещаем об изменении размера отряда
            EventManager.SquadSizeChanged(squad.heroes.Count);
        }
    }

    /// <summary>
    /// Удаляет героя из отряда по его ID
    /// </summary>
    /// <param name="heroID"></param>
    bool RemoveHero(int heroID)
    {
        foreach (var item in squad.heroes)
        {
            if (item.HeroID == heroID)
            {
                squad.heroes.Remove(item);
                //оповещаем об изменении размера отряда
                EventManager.SquadSizeChanged(squad.heroes.Count);
                return true;
            }
        }
        return false;
    }

    public override void Initialize()
    {
        base.Initialize();

        squad = new Squad();

        //подписываемся на повышение уровня лидерства
        EventManager.OnLeadershipChanged += ChangeMaxHeroesAmount;
        //подписываемся на кнопку "купить героя"
        EventManager.OnBuyHeroBttnPressed += AddHero;
    }

    private void OnDestroy()
    {
        EventManager.OnLeadershipChanged -= ChangeMaxHeroesAmount;
        EventManager.OnBuyHeroBttnPressed -= AddHero;
    }
}
