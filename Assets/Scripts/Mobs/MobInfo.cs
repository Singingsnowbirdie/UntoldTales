using UnityEngine;

//Карточка моба

public class MobInfo : ScriptableObject
{
    [Header("Название")]
    [SerializeField] private string heroName;
    public string Name => this.heroName;

    [Header("Ранг")]
    [SerializeField] private int rank;
    public int Rank => this.rank;

    [Header("Запас здоровья")]
    [SerializeField] int health;
    public int Health => this.health;

    [Header("Тип боя (дальний, ближний)")]
    [SerializeField] CombatType сombatType;
    public CombatType СombatType => this.сombatType;

    [Header("Физическая защита")]
    [SerializeField] int physicalProtection;
    public int PhysicalProtection => this.physicalProtection;

    [Header("Магическая защита")]
    [SerializeField] int magicProtection;
    public int MagicProtection => this.magicProtection;

    [Header("Сила атаки: (количество ед. урона за одну атаку)")]
    [SerializeField] int attackPower;
    public int AttackPower => this.attackPower;

    [Header("Скорость атаки: (количество атак в секунду)")]
    [SerializeField] int attackSpeed;
    public int AttackSpeed => this.attackSpeed;

    [Header("Дальность атаки: (в количестве ячеек по прямой)")]
    [SerializeField] int attackRange;
    public int AttackRange => this.attackRange;

    [Header("Префаб")]
    [SerializeField] GameObject pref;
    public GameObject Pref => this.pref;
}
