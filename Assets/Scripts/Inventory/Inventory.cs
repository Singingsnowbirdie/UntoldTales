internal class Inventory
{
    /// <summary>
    /// Текущее количество монет игрока
    /// </summary>
    public int Coins { get; set; }

    /// <summary>
    /// Количество монет у игрока в начале матча
    /// </summary>
    readonly int startCoins = 2;

    /// <summary>
    /// Устанавливает стартовое кол-во монет и оповещает UI и магазин
    /// </summary>
    public void SetStartCoinsAmount()
    {
        Coins = startCoins;
        EventManager.CoinsAmountChanged(Coins);
    }
}