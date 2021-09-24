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
    /// Здесь лежат все герои, которых можно улучшать
    /// </summary>
    public List<Hero> heroesInPlanning;

    /// <summary>
    /// Здесь лежат все герои, которых нельзя улучшать
    /// Когда начинается фаза боя, сюда переносятся все герои, которые находятся на поле (не в резерве)
    /// </summary>
    public List<Hero> heroesInBattle;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Squad()
    {
        heroesInPlanning = new List<Hero>();
        MaxHeroesAmount = startHeroesAmount;
    }
}
