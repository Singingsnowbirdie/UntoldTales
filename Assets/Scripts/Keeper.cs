using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper
{
    /// <summary>
    /// Максимальное кол-во очков здоровья
    /// </summary>
    public readonly int MaxHealth = 100;

    /// <summary>
    /// Уровень лидерства на старте раунда
    /// </summary>
    readonly int startLeadership = 1;

    /// <summary>
    /// Максимальный уровень лидерства 
    /// </summary>
    public readonly int MaxLeadership = 10;

    /// <summary>
    /// Текущие очки лидерства
    /// </summary>
    public int Leadership { get; set; }

    /// <summary>
    /// Текущие очки Здоровья
    /// </summary>
    public int Health { get; set; }

    /// <summary>
    /// Текущие очки опыта
    /// </summary>
    public int Experience { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Keeper()
    {
        Experience = 0;
        Leadership = startLeadership;
        Health = MaxHealth;
    }
}
