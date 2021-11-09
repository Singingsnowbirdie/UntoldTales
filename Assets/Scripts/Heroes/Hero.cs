using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    /// <summary>
    /// Информация о герое (скриптабл обдж.)
    /// </summary>
    [SerializeField] HeroInfo info;

    /// <summary>
    /// Статы героя
    /// </summary>
    protected HeroStats stats;

    /// <summary>
    /// Инвентарь
    /// </summary>
    HeroInventory inventory;

    /// </summary>
    /// Стейт-машина
    /// </summary>
    public StateMachine HeroStateMachine { get; set; }

    /// <summary>
    /// Текущая цель
    /// </summary>
    public Hero CurrentTarget { get; set; }

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
        //ищем инфо героя с таким же именем, но выше рангом, "наклеиваем" его на этого героя
    }

    /// <summary>
    /// Атака
    /// </summary>
    public virtual void Attack()
    {
        Debug.Log("Герой атакует");
    }

    /// <summary>
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Вызывается при размещении героя на поле
    /// </summary>
    void PrepareToBattle()
    {
        //Определяем начальные характеристики героя
        stats = new HeroStats(info);
        //определяем инвентарь героя
        inventory = new HeroInventory();
    }

    /// <summary>
    /// Возвращает имя героя
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return info.Name;
    }

    /// <summary>
    /// Возвращает условную стоимость всех надетых на героя предметов
    /// </summary>
    /// <returns></returns>
    internal int GetEquipmentСost()
    {
        return inventory.EquipmentСost;
    }
}
