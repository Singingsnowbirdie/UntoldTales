using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
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
    /// Здесь лежат все герои, которые находятся на поле, но не в фазе боя
    /// Этих героев можно экипировать, улучшать и продавать
    /// </summary>
    public List<Hero> heroesOnTheField;

    /// <summary>
    /// Здесь лежат все герои, которые находятся в бою
    /// Когда начинается фаза боя, сюда переносятся все герои, которые находятся на поле (не в резерве)
    /// </summary>
    public List<Hero> heroesInBattle;

    /// <summary>
    /// Проверяет, находится ли герой в соответствующем списке
    /// </summary>
    public bool IsInList(Hero hero, List<Hero> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == hero.ID)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Добавляет героя в список 
    /// </summary>
    internal void AddHeroToList(Hero hero, List<Hero> list)
    {
        list.Add(hero);
    }

    /// <summary>
    /// Удаляет героя из списка
    /// </summary>
    /// <param name="item"></param>
    internal bool RemoveHeroFromList(Hero hero, List<Hero> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == hero.ID)
            {
                list.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
