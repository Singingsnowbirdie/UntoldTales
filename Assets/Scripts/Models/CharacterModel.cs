
public class CharacterModel
{
    public CharacterModel(CharacterInfo info)
    {

    }

    //Имеет ульту (герой)
    public bool HasUltimateAbility { get; set; }

    //Запас здоровья
    public int MaxHealth { get; set; }

    //Текущее здоровье
    public float Health { get; set; }

    //Запас маны (герой)
    public int MaxMana { get; set; }

    //Текущая мана (герой)
    public float Mana { get; set; }

    //Запас энергии (для героев, имеющих ульту)
    public int MaxEnergy { get; set; }

    //Текущая энергия (для героев, имеющих ульту)
    public float Energy { get; set; }

    //Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту)
    public int EnergyStorageRate { get; set; }

    //Физическая защита
    public int PhysicalProtection { get; set; }

    //Магическая защита
    public int MagicProtection { get; set; }

    //Сила атаки: (количество ед. урона за одну атаку)
    public int AttackPower { get; set; }

    //Скорость атаки: (количество атак в секунду)
    public float AttackSpeed { get; set; }

    //Дальность атаки: (в количестве ячеек по прямой)
    public int AttackRange { get; set; }
}
