//герой

public class Hero : Character
{
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Инвентарь
    /// </summary>
    public HeroInventory Inventory { get; set; }

    protected override void OnCharacterEnable()
    {
        Model = new HeroModel(Info);
        stateMachine = new CharacterStateMachine(this);
    }

    /// <summary>
    /// Повышает ранг героя
    /// </summary>
    internal void Raise()
    {
        //ищем инфо героя с таким же именем, но выше рангом, "наклеиваем" его на этого героя
    }
}

