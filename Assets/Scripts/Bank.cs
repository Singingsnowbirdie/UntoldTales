internal class Bank
{
    /// <summary>
    /// Текущее количество монет игрока
    /// </summary>
    public int Coins { get; set; }

    /// <summary>
    /// Количество монет у игрока в начале матча
    /// </summary>
    readonly int startCoins = 10;

    /// <summary>
    /// Устанавливает стартовое кол-во монет и оповещает UI и магазин
    /// </summary>
    public void SetStartCoinsAmount()
    {
        Coins = startCoins;
        EventManager.CoinsAmountChanged(Coins);
    }

    /// <summary>
    /// Добавляет монеты 
    /// </summary>
    public void AddCoins(int amount)
    {
        Coins += amount;
        EventManager.CoinsAmountChanged(Coins);
    }

    /// <summary>
    /// Отнимает монеты 
    /// </summary>
    public void SpendCoins(int amount)
    {
        Coins -= amount;
        EventManager.CoinsAmountChanged(Coins);
    }

    /// <summary>
    /// Проверяет, достаточно ли монет для покупки чего-либо
    /// </summary>
    public bool IfEnoughCoins(int cost)
    {
        if (cost <= Coins)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}