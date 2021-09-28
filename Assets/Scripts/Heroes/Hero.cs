using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Тип атаки (физическая, магическая, гибридная)
/// </summary>
public enum HeroAttackType
{
    Physical,
    Magic,
    Hybrid
}

public abstract class Hero : MonoBehaviour
{
    /// <summary>
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Ранг
    /// </summary>
    public int Rank { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Максимальное здоровье
    /// </summary>
    public int MaxHealth { get; set; }

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    public int Health { get; set; }

    /// <summary>
    /// Физическая защита: (количество поглощаемого физического урона)
    /// </summary>
    public int PhysicalProtection { get; set; }

    /// <summary>
    /// Магическая защита: (количество поглощаемого магического урона)
    /// </summary>
    public int MagicProtection { get; set; }

    /// <summary>
    /// Тип атаки (физическая, магическая, гибридная)
    /// </summary>
    public HeroAttackType AttackType { get; set; }

    /// <summary>
    /// Сила атаки: (количество ед. урона за одну атаку)
    /// </summary>
    public int AttackPower { get; set; }

    /// <summary>
    /// Скорость атаки: (количество атак в секунду)
    /// </summary>
    public int AttackSpeed { get; set; }

    /// <summary>
    /// Дальность атаки: (в количестве ячеек по прямой)
    /// </summary>
    public int AttackRange { get; set; }

    /// <summary>
    /// Максимальное значение маны
    /// </summary>
    public readonly int MaxMana = 100;

    /// <summary>
    /// Текущее значение маны
    /// </summary>
    public int Mana { get; set; }

    /// <summary>
    /// Максимальное значение энергии
    /// </summary>
    public readonly int MaxEnergy = 100;

    /// <summary>
    /// Текущее значение энергии
    /// </summary>
    public int Energy { get; set; }

    /// <summary>
    /// Скорость накопления энергии (в секунду)
    /// </summary>
    public int EnergyStorageRate { get; set; }

    /// <summary>
    /// Текущая цель
    /// </summary>
    public Hero CurrentTarget { get; set; }

    /// <summary>
    /// Суммарная стоимость всех экипированных предметов
    /// </summary>
    public int EquipmentСost { get; set; }

    /// <summary>
    /// Жизненный цикл героя (после активации = после помещения на поле боя)
    /// </summary>
    /// <returns></returns>
    public IEnumerator HeroLifeCycleRoutine()
    {
        yield return null;
    }

    /// <summary>
    /// "Снимает" с героя все надетые на него предметы
    /// Передает их во временный рюкзак
    /// </summary>
    /// <returns></returns>
    internal List<Item> TakeOffAllItems()
    {
        //дописать
        return new List<Item>();
    }

    /// <summary>
    /// Повышает ранг героя
    /// </summary>
    internal void Raise()
    {
        Rank++;
    }

    /// <summary>
    /// Выбор цели
    /// </summary>
    public void SelectTarget()
    {
        Debug.Log("Цель выбрана");
    }

    /// <summary>
    /// Двигает персонажа
    /// </summary>
    public void Move()
    {
        Debug.Log("Герой двигается");
    }

    /// <summary>
    /// Атака
    /// </summary>
    public void Attack()
    {
        Debug.Log("Герой атакует");
    }
}
