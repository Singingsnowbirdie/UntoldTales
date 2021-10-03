using UnityEngine;
using UnityEngine.UI;

// UI раунда (тест) 

public class RoundUI : MonoBehaviour
{
    /// <summary>
    /// Текст: очки опыта Хранителя
    /// </summary>
    [SerializeField] Text experienceCounter;

    /// <summary>
    /// Текст: количество очков лидерства
    /// </summary>
    [SerializeField] Text leadershipCounter;

    /// <summary>
    /// Текст: количество очков здоровья
    /// </summary>
    [SerializeField] Text keeperHealthCounter;

    /// <summary>
    /// Текст: количество героев в резерве
    /// </summary>
    [SerializeField] Text heroesInReserveCounter;

    /// <summary>
    /// Текст: количество героев во временном хранилище
    /// </summary>
    [SerializeField] Text heroesInTemporaryStorageCounter;

    /// <summary>
    /// Текст: количество героев на поле
    /// </summary>
    [SerializeField] Text heroesOnTheFieldCounter;

    /// <summary>
    /// Текст: количество монет
    /// </summary>
    [SerializeField] Text coinsCounter;

    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //подписываемся на изменение чего-либо
        EventManager.OnSomethingChanged += SomethingChanged;
    }

    /// <summary>
    /// Количество чего-то поменялось
    /// </summary>
    private void SomethingChanged(int amount, Changeables value)
    {
        if (value == Changeables.Experience) leadershipCounter.text = $"Уровень лидерства: {amount}";
        else if (value == Changeables.Leadership) { experienceCounter.text = $"Очки опыта Хранителя: {amount}"; }
        else if (value == Changeables.Health) { keeperHealthCounter.text = $"Очков здоровья: {amount}"; }
        else if (value == Changeables.Coins) { coinsCounter.text = $"Монет: {amount}"; }
        else if (value == Changeables.Reserve) { heroesInReserveCounter.text = $"Героев в резерве: {amount}"; }
        else if (value == Changeables.Storage) { heroesInTemporaryStorageCounter.text = $"Героев во временном хранилище: {amount}"; }
        else if (value == Changeables.Field) { heroesOnTheFieldCounter.text = $"Героев на поле: {amount}"; }
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnSomethingChanged -= SomethingChanged;
    }

    #region КНОПКИ
    /// <summary>
    /// Кнопка "купить опыт Хранителя"
    /// </summary>
    public void BuyExperience()
    {
        EventManager.OnBttnPressedEventInvoke(Bttns.BuyExperienceBttn);
    }

    /// <summary>
    /// Кнопка "купить героя"
    /// </summary>
    public void BuyHero()
    {
        Hero hero = new UltimateHeroExample();
        EventManager.OnHeroPurchasedEventInvoke(hero);
    }
    #endregion

}
