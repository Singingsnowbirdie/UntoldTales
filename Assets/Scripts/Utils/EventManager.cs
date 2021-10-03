﻿using System;

//менеджер событий (синглтон)

public class EventManager
{
    private static EventManager _instance;

    public static EventManager instance
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
    internal static void OnSomethingPurchasedEventInvoke(int amount, Purchasables value) { OnSomethingPurchased?.Invoke(amount, value); }
    public static event Action<int, Purchasables> OnSomethingPurchased;
    #endregion

    #region ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЧЕГО-ТО (передаем сколько стало и чего)
    internal static void OnSomethingChangedEventInvoke(int amount, Changeables value) { OnSomethingChanged?.Invoke(amount, value); }
    public static event Action<int, Changeables> OnSomethingChanged;
    #endregion

    #region КУПЛЕН ГЕРОЙ
    internal static void OnHeroPurchasedEventInvoke(Hero hero) { OnHeroPurchased?.Invoke(hero); }
    public static event Action<Hero> OnHeroPurchased;
    #endregion

    #region НАЖАТА КНОПКА
    internal static void OnBttnPressedEventInvoke(Bttns bttn) { OnBttnPressed?.Invoke(bttn); }
    public static event Action<Bttns> OnBttnPressed;
    #endregion
}
