
public class CharacterModel
{
    /// <summary>
    /// Максимальное здоровье (в единицах)
    /// </summary>
    protected int maxHealth;

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    public float Health { get; set; }

    /// <summary>
    /// Физическая защита: (количество поглощаемого физического урона)
    /// </summary>
    protected int physicalProtection;

    /// <summary>
    /// Магическая защита: (количество поглощаемого магического урона)
    /// </summary>
    protected int magicProtection;

    /// <summary>
    /// Сила атаки: (количество ед. урона за одну атаку)
    /// </summary>
    protected int attackPower;

    /// <summary>
    /// Скорость атаки: (количество атак в секунду)
    /// </summary>
    public float AttackSpeed { get; set; }

    /// <summary>
    /// Тип атаки по дальности (ближняя, дальняя)
    /// </summary>
    public CombatType СombatType { get; set; }

    /// <summary>
    /// Дальность атаки: (в количестве ячеек по прямой)
    /// </summary>
    protected int attackRange;

    public CharacterModel(CharacterInfo info)
    {
        maxHealth = info.Health;
        physicalProtection = info.PhysicalProtection;
        magicProtection = info.MagicProtection;
        attackPower = info.AttackPower;
        AttackSpeed = info.AttackSpeed;
        СombatType = info.CombatType;
        attackRange = info.AttackRange;
        Health = maxHealth;
    }
}
