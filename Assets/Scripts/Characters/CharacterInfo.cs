using UnityEngine;

//чтобы вызывать быстро из меню
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Script/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [HideInInspector]
    //Герой (или моб)
    public bool IsHero;

    [HideInInspector]
    //Имя
    public string Name;

    [HideInInspector]
    //Ранг
    public int Rank;

    [HideInInspector]
    //Фракция (герой)
    public Fraction Fraction;

    [HideInInspector]
    //Класс (герой)
    public Class Class;

    [HideInInspector]
    //Имеет ульту (герой)
    public bool HasUltimateAbility;

    [HideInInspector]
    //Запас здоровья
    public int Health;

    [HideInInspector]
    //Запас маны (герой)
    public int Mana;

    [HideInInspector]
    //Запас энергии (для героев, имеющих ульту)
    public int Energy;

    [HideInInspector]
    //Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту)
    public int EnergyStorageRate;

    [HideInInspector]
    //Физическая защита3ES
    public int PhysicalProtection;

    [HideInInspector]
    //Магическая защита
    public int MagicProtection;

    [HideInInspector]
    //Тип атаки (физическая, магическая, гибридная) (герой)
    public AttackType AttackType;

    [HideInInspector]
    //Стиль боя (ближний, дальний) (моб)
    public CombatType CombatType;

    [HideInInspector]
    //Сила атаки: (количество ед. урона за одну атаку)
    public int AttackPower;

    [HideInInspector]
    //Скорость атаки: (количество атак в секунду)
    public float AttackSpeed;

    [HideInInspector]
    //Дальность атаки: (в количестве ячеек по прямой)
    public int AttackRange;
}
