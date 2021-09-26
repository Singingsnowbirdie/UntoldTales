using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    /// <summary>
    /// Максимальное количество героев в резерве
    /// </summary>
    public readonly int maxHeroesInReserveAndTemp = 8;

    /// <summary>
    /// Начальное значение, максимального кол-ва героев на поле
    /// </summary>
    readonly int startHeroesOnTheFieldAmount = 1;

    /// <summary>
    /// Максимальное кол-во героев на поле (зависит от уровня Хранителя)
    /// </summary>
    public int MaxHeroesOnTheFieldAmount { get; set; }

    /// <summary>
    /// Последний присвоенный ID
    /// </summary>
    public int LastID { get; set; }

    /// <summary>
    /// Временное хранилище
    /// Здесь лежат все купленные герои, которые не поместились в резерве
    /// </summary>
    public List<Hero> temporaryStorage;

    /// <summary>
    /// Здесь лежат все герои, которые находятся в резерве (не на поле)
    /// </summary>
    public List<Hero> heroesInReserve;

    /// <summary>
    /// Здесь лежат все герои, которые находятся на поле
    /// </summary>
    public List<Hero> heroesOnTheField;

    /// <summary>
    /// Здесь лежат все герои, которые находятся в бою
    /// Когда начинается фаза боя, сюда переносятся все герои, которые находятся на поле (не в резерве)
    /// </summary>
    public List<Hero> heroesInBattle;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Squad()
    {
        temporaryStorage = new List<Hero>();
        heroesInReserve = new List<Hero>();
        heroesOnTheField = new List<Hero>();
        heroesInBattle = new List<Hero>();
        MaxHeroesOnTheFieldAmount = startHeroesOnTheFieldAmount;
    }

    /// <summary>
    /// Удаляет героя с поля
    /// </summary>
    /// <param name="item"></param>
    internal void RemoveHeroFromField(Hero hero)
    {
        foreach (var item in heroesOnTheField)
        {
            if (item.ID == hero.ID)
            {
                heroesOnTheField.Remove(item);
                EventManager.HeroesOnTheFieldAmountChanged(heroesOnTheField.Count);
                break;
            }
        }
    }

    /// <summary>
    /// Удаляет героя из резерва
    /// </summary>
    /// <param name="item"></param>
    internal void RemoveHeroFromReserve(Hero hero)
    {
        for (int i = 0; i < heroesInReserve.Count; i++)
        {
            if (heroesInReserve[i].ID == hero.ID)
            {
                heroesInReserve.RemoveAt(i);
                EventManager.ReserveSizeChanged(heroesInReserve.Count);
                break;
            }
        }
    }
}
