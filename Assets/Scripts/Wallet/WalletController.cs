public class WalletController : Controller
{
    /// <summary>
    /// Репозиторий кошелька
    /// Здесь будут храниться все валюты игры
    /// </summary>
    WalletRepository repository;

    /// <summary>
    /// При создании
    /// </summary>
    public override void OnCreate()
    {
        base.OnCreate();
    }

    /// <summary>
    /// Достаем монетки
    /// </summary>
    public int Coins => repository.Coins;

    /// <summary>
    /// Проверяем, хватает ли монет
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsEnoughCoins(int value)
    {
        return Coins >= value;
    }

    /// <summary>
    /// Добавляем монеты
    /// </summary>
    /// <param name="sender">Кто инициировал</param>
    /// <param name="value">Сколько подобрано</param>
    public void AddCoins(object sender, int value)
    {
        repository.Coins += value;
        repository.Save();
    }

    /// <summary>
    /// Тратим монеты
    /// </summary>
    /// <param name="sender">Кто инициировал</param>
    /// <param name="value">Сколько потратили</param>
    public void SpendCoins(object sender, int value)
    {
        repository.Coins -= value;
        repository.Save();
    }
}
