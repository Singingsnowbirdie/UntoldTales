using UnityEngine;

//Характеристики героя

public class HeroStats : MonoBehaviour
{
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

    /// <summary>
    /// Максимальное значение энергии
    /// (Начальное значение берется из карточки (инфо), потом меняется, под действием модификаторов)
    /// </summary>
    int maxEnergy;

    /// <summary>
    /// Сколько энергии герой получает за одну атаку по цели
    /// </summary>
    int energyStorageRate;

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    int health;

    /// <summary>
    /// Текущее значение маны
    /// </summary>
    int mana;

    /// <summary>
    /// Текущее значение энергии
    /// </summary>
    int energy;

    public HeroStats(HeroInfo info)
    {
        maxHealth = info.Health;
        maxMana = info.Mana;
        maxEnergy = info.MaxEnergy;
        energyStorageRate = info.EnergyStorageRate;
        physicalProtection = info.PhysicalProtection;
        magicProtection = info.MagicProtection;
        attackPower = info.AttackPower;
        attackSpeed = info.AttackSpeed;
        attackRange = info.AttackRange;

        mana = 0;
        energy = 0;
        health = maxHealth;
    }

    /// <summary>
    /// Пополняет энергию
    /// Проверяет, достаточно ли энергии для проведения ульты
    /// </summary>
    public bool AddEnergy()
    {
        energy += energyStorageRate;
        if (energy >= maxEnergy)
        {
            energy -= maxEnergy;
            return true;
        }
        return false;
    }
}
