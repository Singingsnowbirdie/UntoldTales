
public class CharacterModel 
{
    /// <summary>
    /// Максимальное здоровье (в единицах)
    /// </summary>
    protected int maxHealth;

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    protected float health;

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
    protected float attackSpeed;

    /// <summary>
    /// Дальность атаки: (в количестве ячеек по прямой)
    /// </summary>
    protected int attackRange;

    public CharacterModel(CharacterInfo info)
    {
        this.maxHealth = info.Health;
        this.physicalProtection = info.PhysicalProtection;
        this.magicProtection = info.MagicProtection;
        this.attackPower = info.AttackPower;
        this.attackSpeed = info.AttackSpeed;
        this.attackRange = info.AttackRange;
        this.health = info.Health;
    }
}
