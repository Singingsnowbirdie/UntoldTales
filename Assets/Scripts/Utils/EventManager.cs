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


    #region ЗАГРУЗКА СЦЕНЫ
    internal static void LoadScene(string sceneName) { OnSceneLoad?.Invoke(sceneName); }
    public static event Action<string> OnSceneLoad;
    #endregion

    #region ВХОД В СОСТОЯНИЕ
    internal static void OnStageEnterEventInvoke(IStage stage) { OnStageEnter?.Invoke(stage); }
    public static event Action<IStage> OnStageEnter;
    #endregion

    #region ВЫХОД ИЗ СОСТОЯНИЯ
    internal static void OnStageExitEventInvoke(IStage stage) { OnStageExit?.Invoke(stage); }
    public static event Action<IStage> OnStageExit;
    #endregion

    #region КУПЛЕНО ЧТО-ТО (передаем сколько и чего)
    internal static void OnSomethingPurchasedEventInvoke(int amount, Purchasable value) { OnSomethingPurchased?.Invoke(amount, value); }
    public static event Action<int, Purchasable> OnSomethingPurchased;
    #endregion

    #region ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЧЕГО-ТО (передаем сколько стало и чего)
    internal static void OnSomethingChangedEventInvoke(int amount, Changeable value) { OnSomethingChanged?.Invoke(amount, value); }
    public static event Action<int, Changeable> OnSomethingChanged;
    #endregion

    #region ПРИОБРЕТЕН ГЕРОЙ (куплен или получен иначе)
    internal static void OnHeroPurchasedEventInvoke(string heroName) { OnHeroPurchased?.Invoke(heroName); }
    public static event Action<string> OnHeroPurchased;
    #endregion

    #region НАЖАТА КНОПКА
    internal static void OnBttnPressedEventInvoke(Bttn bttn) { OnBttnPressed?.Invoke(bttn); }
    public static event Action<Bttn> OnBttnPressed;
    #endregion

    #region КЛИК ПО ГЕРОЮ (используется на круге героев)
    internal static void OnHeroSelectedEventInvoke(string heroName) { OnHeroSelected?.Invoke(heroName); }
    public static event Action<string> OnHeroSelected;
    #endregion
}
