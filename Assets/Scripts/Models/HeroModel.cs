using System.Collections;
using System.Collections.Generic;
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
    private int fraction;

    /// <summary>
    /// Класс
    /// </summary>
    private int heroClass;

    /// <summary>
    /// маны
    /// </summary>
    private int mana;

    /// <summary>
    /// Максимум маны"
    /// </summary>
    private int maxMana;

    /// <summary>
    /// Имет ульту?
    /// </summary>
    private int hasUltimateAbility;

    /// <summary>
    /// Максимальное значение энергии
    /// </summary>
    private int maxEnergy;

    /// <summary>
    /// Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту
    /// </summary>
    private int energyStorageRate;

    /// <summary>
    /// Иконка
    /// </summary>
    private int sprite;


    public HeroModel(CharacterInfo info) : base(info)
    {

    }
}
