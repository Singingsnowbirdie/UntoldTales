using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот герой умеет накапливать энергию, имеет ульту

public class UltimateHero : Hero
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="info"></param>
    public UltimateHero(HeroInfo info) : base(info) 
    {
        maxEnergy = info.MaxEnergy;
        energy = 0;
        energyStorageRate = info.EnergyStorageRate;
    }

    /// <summary>
    /// Максимальное значение энергии
    /// (Начальное значение берется из карточки (инфо), потом меняется, под действием модификаторов)
    /// </summary>
    int maxEnergy;

    /// <summary>
    /// Текущее значение энергии
    /// </summary>
    int energy;

    /// <summary>
    /// Сколько энергии герой получает за одну атаку по цели
    /// </summary>
    int energyStorageRate;

    /// <summary>
    /// Следующая атака - ульта?
    /// </summary>
    bool IsUltimateAttack;

    public override void Attack()
    {
        base.Attack();
        if (IsUltimateAttack)
        {
            UltimateAttack();
        }
        else
        {
            OrdinaryAttack();
        }
        AddEnergy();
    }

    /// <summary>
    /// Обычная атака
    /// </summary>
    void OrdinaryAttack()
    {
        Debug.Log("OrdinaryAttack");
    }

    /// <summary>
    /// Атака ультой
    /// </summary>
    void UltimateAttack()
    {
        IsUltimateAttack = false;
        Debug.Log("UltimateAttack");
    }

    /// <summary>
    /// Пополняет энергию
    /// Проверяет, достаточно ли энергии для проведения ульты
    /// </summary>
    void AddEnergy()
    {
        energy += energyStorageRate;
        if (energy >= maxEnergy)
        {
            energy -= maxEnergy;
            IsUltimateAttack = true;
        }
    }
}
