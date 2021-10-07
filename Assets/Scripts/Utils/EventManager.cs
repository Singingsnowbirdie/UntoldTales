using System;
using System.Collections.Generic;
using UnityEngine;

//менеджер событий

public class EventManager
{
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null) _instance = new EventManager();
            return _instance;
        }
    }

    #region ВХОД В СОСТОЯНИЕ
    internal static void OnStageEnterEventInvoke(string stage) { OnStageEnter?.Invoke(stage); }
    public static event Action<string> OnStageEnter;
    #endregion

    #region ВЫХОД ИЗ СОСТОЯНИЯ
    internal static void OnStageExitEventInvoke(string stage) { OnStageExit?.Invoke(stage); }
    public static event Action<string> OnStageExit;
    #endregion

    #region КУПЛЕНО ЧТО-ТО (передаем сколько и чего)
    internal static void OnSomethingPurchasedEventInvoke(int amount, Purchasable value) { OnSomethingPurchased?.Invoke(amount, value); }
    public static event Action<int, Purchasable> OnSomethingPurchased;
    #endregion

    #region ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЧЕГО-ТО (передаем сколько стало и чего)
    internal static void OnSomethingChangedEventInvoke(int amount, Changeable value) { OnSomethingChanged?.Invoke(amount, value); }
    public static event Action<int, Changeable> OnSomethingChanged;
    #endregion

    #region КУПЛЕН ГЕРОЙ
    internal static void OnHeroPurchasedEventInvoke(Hero hero) { OnHeroPurchased?.Invoke(hero); }
    public static event Action<Hero> OnHeroPurchased;
    #endregion

    #region НАЖАТА КНОПКА
    internal static void OnBttnPressedEventInvoke(Bttn bttn) { OnBttnPressed?.Invoke(bttn); }
    public static event Action<Bttn> OnBttnPressed;
    #endregion

    #region КЛИК ПО ГЕРОЮ (используется на круге героев)
    internal static void OnHeroPointedEventInvoke(Hero hero) { OnHeroPointed?.Invoke(hero); }
    public static event Action<Hero> OnHeroPointed;
    #endregion
}
