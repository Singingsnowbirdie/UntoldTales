using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    /// <summary>
    /// Начальное значение, максимального кол-ва героев
    /// </summary>
    readonly int startHeroesAmount = 1;

    /// <summary>
    /// Максимальное кол-во героев в отряде (зависит от уровня Хранителя)
    /// </summary>
    public int MaxHeroesAmount { get; set; }

    /// <summary>
    /// Последний присвоенный ID
    /// </summary>
    public int LastID { get; set; }

    /// <summary>
    /// Все герои отряда
    /// </summary>
    public List<Hero> heroes;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Squad()
    {
        heroes = new List<Hero>();
        MaxHeroesAmount = startHeroesAmount;
    }
}
