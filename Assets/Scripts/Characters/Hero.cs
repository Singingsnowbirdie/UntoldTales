//герой

using System;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int squadID { get; set; }

    /// <summary>
    /// Инвентарь
    /// </summary>
    public HeroInventory Inventory { get; set; }

    /// <summary>
    /// Повышает ранг героя
    /// </summary>
    internal void Raise(List<Item> items)
    {
        //ищем инфо героя с таким же именем, но выше рангом, "наклеиваем" его на этого героя
        //не забываем заново одеть его
    }

    /// <summary>
    /// Следующая атака - ульта?
    /// </summary>
    bool IsUltimateAttack;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Hero(CharacterInfo characterInfo)
    {
        Info = characterInfo;
    }

    /// <summary>
    /// Атака
    /// </summary>
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
        IsUltimateAttack = AddEnergy();
    }

    //добавляет энергию
    private bool AddEnergy()
    {
        //дописать
        return false;
    }

    /// <summary>
    /// Обычная атака
    /// </summary>
    void OrdinaryAttack()
    {
        Debug.Log("OrdinaryAttack");
    }

    /// <summary>
    /// Повышает ранг героя и надевает на него предметы
    /// </summary>
    /// <param name="temporaryBackpack"></param>
    internal void RaiseAndEquip(List<Item> temporaryBackpack)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Атака ультой
    /// </summary>
    void UltimateAttack()
    {
        IsUltimateAttack = false;
        Debug.Log("UltimateAttack");
    }
}

