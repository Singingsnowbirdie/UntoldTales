internal class Inventory
{
    public Inventory()
    {
        Coins = startCoins;
    }

    /// <summary>
    /// Текущее количество монет игрока
    /// </summary>
    public int Coins { get; set; }

    /// <summary>
    /// Количество монет у игрока в начале матча
    /// </summary>
    readonly int startCoins = 100;
}