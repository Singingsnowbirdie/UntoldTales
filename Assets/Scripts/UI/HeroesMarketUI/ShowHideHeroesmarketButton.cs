using TMPro;
using UnityEngine;

//кнопка показывает и скрывает панель магазина героев
//также на ней отображается количество денег игрока

public class ShowHideHeroesmarketButton : MonoBehaviour
{
    /// <summary>
    /// Текст: количество монет
    /// </summary>
    [SerializeField] TextMeshProUGUI coinsCounter;

    /// <summary>
    /// Магазин героев (панелька)
    /// </summary>
    [SerializeField] GameObject heroesMarketPanel;

    private void OnEnable()
    {
        //подписываемся на изменение чего-либо
        EventManager.OnSomethingChanged += SomethingChanged;
    }

    /// <summary>
    /// Количество чего-то поменялось
    /// </summary>
    private void SomethingChanged(int amount, Changeable value)
    {
        if (value == Changeable.Coins) { coinsCounter.text = $"{amount}"; }
    }

    /// <summary>
    /// Показывает и скрывает панель магазина
    /// </summary>
    public void ShowHideMarket()
    {
        heroesMarketPanel.SetActive(!heroesMarketPanel.activeSelf);
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnSomethingChanged -= SomethingChanged;
    }
}
