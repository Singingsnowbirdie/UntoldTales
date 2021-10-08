using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    #region ПОКАЗАТЕЛИ (Начальное значение берется из карточки (инфо), потом меняется, под действием модификаторов)
    /// <summary>
    /// Максимальное здоровье (в единицах)
    /// </summary>
    int maxHealth;

    /// <summary>
    /// Физическая защита: (количество поглощаемого физического урона)
    /// </summary>
    int physicalProtection;

    /// <summary>
    /// Магическая защита: (количество поглощаемого магического урона)
    /// </summary>
    int magicProtection;

    /// <summary>
    /// Сила атаки: (количество ед. урона за одну атаку)
    /// </summary>
    int attackPower;

    /// <summary>
    /// Скорость атаки: (количество атак в секунду)
    /// </summary>
    int attackSpeed;

    /// <summary>
    /// Дальность атаки: (в количестве ячеек по прямой)
    /// </summary>
    int attackRange;

    /// <summary>
    /// Максимальное количество маны
    /// </summary>
    int maxMana;
    #endregion

    #region РЕСУРСЫ (здоровье, мана)
    /// <summary>
    /// Текущее здоровье
    /// </summary>
    int health;

    /// <summary>
    /// Текущее значение маны
    /// </summary>
    int mana;
    #endregion

    /// <summary>
    /// Инициализатор
    /// Все эти показатели не нужны герою на "Круге", но нужны в бою, поэтому запускаем инициализацию после покупки героя
    /// </summary>
    public virtual void Initialize()
    {
        maxHealth = info.Health;
        health = maxHealth;
        maxMana = info.Mana;
        mana = maxMana;
        physicalProtection = info.PhysicalProtection;
        magicProtection = info.MagicProtection;
        attackPower = info.AttackPower;
        attackSpeed = info.AttackSpeed;
        attackRange = info.AttackRange;
    }

    /// <summary>
    /// Текущая цель
    /// </summary>
    public Hero CurrentTarget { get; set; }

    /// <summary>
    /// Суммарная стоимость всех экипированных предметов (в единицах)
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
        //ищем инфо героя с таким же именем, но выше рангом, "наклеиваем" его на этого героя
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
    public virtual void Attack()
    {
        Debug.Log("Герой атакует");
    }

    /// <summary>
    /// Информация о герое
    /// </summary>
    public HeroInfo info;

    /// <summary>
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Самоуничтожение
    /// </summary>
    internal void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
