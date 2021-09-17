using UnityEngine;

public class WalletRepository : Repository
{
    /// <summary>
    /// Ключ для playerPrefs
    /// </summary>
    const string KEY = "COINS";

    /// <summary>
    /// Монеты
    /// </summary>
    public int Coins { get; set; }

    /// <summary>
    /// Инициализируем данные кошелька
    /// </summary>
    public override void Initialize()
    {
        //если нет ключа - создаем
        if (!PlayerPrefs.HasKey(KEY)) PlayerPrefs.SetInt(KEY, 0);
        //получаем данные
        Coins = PlayerPrefs.GetInt(KEY, 0);
    }

    /// <summary>
    /// Сохраняем данные кошелька
    /// </summary>
    public override void Save()
    {
        PlayerPrefs.SetInt(KEY, Coins);
    }

    internal override void OnCreate()
    {
        throw new System.NotImplementedException();
    }

    internal override void OnStart()
    {
        throw new System.NotImplementedException();
    }
}
