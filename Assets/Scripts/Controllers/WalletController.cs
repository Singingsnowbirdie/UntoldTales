public class WalletController : IController
{
    /// <summary>
    /// Репозиторий кошелька
    /// Здесь будут храниться все валюты игры
    /// </summary>
    WalletRepository repository;

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

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnCreate()
    {
        throw new System.NotImplementedException();
    }
}
