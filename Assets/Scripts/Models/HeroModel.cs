using UnityEngine;

public class HeroModel : CharacterModel
{
    /// <summary>
    /// Ранг
    /// </summary>
    private int rank;

    /// <summary>
    /// Фракция
    /// </summary>
    private Fraction fraction;

    /// <summary>
    /// Класс
    /// </summary>
    private Class heroClass;

    /// <summary>
    /// Мана
    /// </summary>
    private int mana;

    /// <summary>
    /// Максимальное значение маны
    /// </summary>
    private int maxMana;

    /// <summary>
    /// Имет ульту
    /// </summary>
    private bool hasUltimateAbility;

    /// <summary>
    /// Максимальное значение энергии
    /// </summary>
    private int maxEnergy;

    /// <summary>
    /// Энергия
    /// </summary>
    public int Energy { get; set; }

    /// <summary>
    /// Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту)
    /// </summary>
    public int EnergyStorageRate { get; set; }

    /// <summary>
    /// Иконка
    /// </summary>
    private Sprite sprite;

    public HeroModel(CharacterInfo info) : base(info)
    {
        rank = info.Rank;
        fraction = info.Fraction;
        heroClass = info.Class;
        maxMana = info.Mana;
        mana = 0;
        hasUltimateAbility = info.HasUltimateAbility;
        maxEnergy = info.Energy;
        Energy = 0;
        EnergyStorageRate = info.EnergyStorageRate;
    }
}
