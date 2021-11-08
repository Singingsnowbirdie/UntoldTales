using UnityEngine;

//Важно! Один и тот же герой разного ранга - это РАЗНЫЕ скриптуемые объекты
//Возможно, стоит сразу добавлять в карточку ссылки на инфо этого же героя, но других рангов (подумать)  

//чтобы вызывать быстро из меню
[CreateAssetMenu(fileName = "HeroInfo", menuName = "Script/HeroInfo")]

public class HeroInfo : ScriptableObject
{
    [Header("Имя героя")]
    [SerializeField] private string heroName;
    public string Name => this.heroName;

    [Header("Ранг")]
    [SerializeField] private int rank;
    public int Rank => this.rank;

    [Header("Фракция")]
    [SerializeField] Fraction fraction;
    public Fraction Fraction => this.fraction;

    [Header("Класс")]
    [SerializeField] Class heroClass;
    public Class Class => this.heroClass;

    [Header("Запас здоровья")]
    [SerializeField] int health;
    public int Health => this.health;

    [Header("Запас маны")]
    [SerializeField] int mana;
    public int Mana => this.mana;

    [Header("Физическая защита")]
    [SerializeField] int physicalProtection;
    public int PhysicalProtection => this.physicalProtection;

    [Header("Магическая защита")]
    [SerializeField] int magicProtection;
    public int MagicProtection => this.magicProtection;

    [Header("Тип атаки (физическая, магическая, гибридная)")]
    [SerializeField] AttackType attackType;
    public AttackType AttackType => this.attackType;

    [Header("Сила атаки: (количество ед. урона за одну атаку)")]
    [SerializeField] int attackPower;
    public int AttackPower => this.attackPower;

    [Header("Скорость атаки: (количество атак в секунду)")]
    [SerializeField] int attackSpeed;
    public int AttackSpeed => this.attackSpeed;

    [Header("Дальность атаки: (в количестве ячеек по прямой)")]
    [SerializeField] int attackRange;
    public int AttackRange => this.attackRange;

    [Header("Имет ульту?")]
    [SerializeField] bool hasUltimateAbility;
    public bool HasUltimateAbility => this.hasUltimateAbility;

    [Header("Максимальное значение энергии (для героев, имеющих ульту)")]
    [SerializeField] int maxEnergy;
    public int MaxEnergy => this.maxEnergy;

    [Header("Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту)")]
    [SerializeField] int energyStorageRate;
    public int EnergyStorageRate => this.energyStorageRate;

    [Header("Префаб")]
    [SerializeField] GameObject pref;
    public GameObject Pref => this.pref;

}

