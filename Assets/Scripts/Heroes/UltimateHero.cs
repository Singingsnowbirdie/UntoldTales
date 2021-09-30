using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//от этого класса наследуются все герои, умеющие накапливать энергию и имеющие ульту

public abstract class UltimateHero : Hero
{
    /// <summary>
    /// Максимальное значение энергии
    /// </summary>
    public readonly int MaxEnergy = 100;

    /// <summary>
    /// Текущее значение энергии
    /// </summary>
    public int Energy { get; set; }

    /// <summary>
    /// Сколько энергии герой получает за одну атаку по цели
    /// </summary>
    public readonly int EnergyStorageRate = 10;

    /// <summary>
    /// Следующая атака - ульта?
    /// </summary>
    public bool IsUltimateAttack;

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
    private void OrdinaryAttack()
    {
        Debug.Log("OrdinaryAttack");
    }

    /// <summary>
    /// Атака ультой
    /// </summary>
    private void UltimateAttack()
    {
        IsUltimateAttack = false;
        Debug.Log("UltimateAttack");
    }

    /// <summary>
    /// Пополняет энергию
    /// Проверяет, достаточно ли энергии для проведения ульты
    /// </summary>
    private void AddEnergy()
    {
        Energy += EnergyStorageRate;
        if (Energy >= MaxEnergy)
        {
            Energy -= MaxEnergy;
            IsUltimateAttack = true;
        }
    }
}
