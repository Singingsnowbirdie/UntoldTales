using System;

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

    #region СОБЫТИЯ: Матч
    //Вход в начальную стадию
    public static event Action OnMatchInitialStageEnter;
    //Выход из начальной стадии
    public static event Action OnMatchInitialStageExit;
    //Вход в раннюю стадию
    public static event Action OnMatchEarlyStageEnter;
    //Выход из ранней стадии
    public static event Action OnMatchEarlyStageExit;
    //Вход в позднюю стадию
    public static event Action OnMatchLateStageEnter;
    //Выход из поздней стадии
    public static event Action OnMatchLateStageExit;
    //Вход в финальную стадию
    public static event Action OnMatchFinalStageEnter;
    //Выход из финальной стадии
    public static event Action OnMatchFinalStageExit;
    #endregion

    #region СОБЫТИЯ: Раунд
    //Вход в фазу планирования
    public static event Action OnRoundPlanningStageEnter;
    //Выход из фазы планирования
    public static event Action OnRoundPlanningStageExit;
    //Вход в фазу боя
    public static event Action OnRoundBattleStageEnter;
    //Выход из фазы боя
    public static event Action OnRoundBattleStageExit;
    //Вход в фазу расчетов
    public static event Action OnRoundCalculationStageEnter;
    //Выход из фазы расчетов
    public static event Action OnRoundCalculationStageExit;
    //Вход в фазу подбора соперников
    public static event Action OnRoundOpponentSelectionStageEnter;
    //Выход из фазы подбора соперников
    public static event Action OnRoundOpponentSelectionStageExit;
    #endregion

    #region СОБЫТИЯ: Хранитель
    // Куплен опыт
    public static event Action<int> OnKeeperExperiencePurchased;
    // Изменилось количество опыта Хранителя (и, иногда, уровень лидерства)
    public static event Action<int, int> OnExperienceChanged;
    // Изменилось количество очков здоровья
    public static event Action<int> OnKeeperHealthChanged;
    #endregion

    #region СОБЫТИЯ: Отряд
    //Куплен герой
    public static event Action<Hero> OnHeroPurchased;
    // Изменилось количество героев в резерве
    public static event Action<int> OnReserveSizeChanged;
    // Изменилось количество героев во временном хранилище
    public static event Action<int> OnTemporaryStorageSizeChanged;
    // Изменилось количество героев на поле
    public static event Action<int> OnHeroesOnTheFieldAmountChanged;
    #endregion

    #region СОБЫТИЯ: UI матч
    //Нажата кнопка "сменить стадию матча"
    public static event Action OnChangeMatchStageBttnPressed;
    #endregion

    #region СОБЫТИЯ: UI раунд
    //Нажата кнопка "сменить фазу раунда"
    public static event Action OnChangeRoundStageBttnPressed;
    //Нажата кнопка "купить опыт Хранителя"
    public static event Action OnBuyExperienceBttnPressed;
    //Изменилось количество монет у игрока
    public static event Action<int> OnCoinsAmountChanged;
    #endregion

    #region МЕТОДЫ: Матч
    /// <summary>
    /// Вход в начальную стадию
    /// </summary>
    internal static void MatchInitialStageEnterEventInvoke() { OnMatchInitialStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из начальной стадии
    /// </summary>
    internal static void MatchInitialStageExitEventInvoke() { OnMatchInitialStageExit?.Invoke(); }
    /// <summary>
    /// Вход в раннюю стадию
    /// </summary>
    internal static void MatchEarlyStageEnterEventInvoke() { OnMatchEarlyStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из ранней стадии
    /// </summary>
    internal static void MatchEarlyStageExitEventInvoke() { OnMatchEarlyStageExit?.Invoke(); }
    /// <summary>
    /// Вход в позднюю стадию
    /// </summary>
    internal static void MatchLateStageEnterEventInvoke() { OnMatchLateStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из поздней стадии
    /// </summary>
    internal static void MatchLateStageExitEventInvoke() { OnMatchLateStageExit?.Invoke(); }
    /// <summary>
    /// Вход в финальную стадию
    /// </summary>
    internal static void MatchFinalStageEnterEventInvoke() { OnMatchFinalStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из финальной стадии
    /// </summary>
    internal static void MatchFinalStageExitEventInvoke() { OnMatchFinalStageExit?.Invoke(); }
    #endregion

    #region МЕТОДЫ: Раунд
    /// <summary>
    /// Вход в фазу планирования
    /// </summary>
    public static void RoundPlanningStageEnterEventInvoke() { OnRoundPlanningStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы планирования
    /// </summary>
    public static void RoundPlanningStageExitEventInvoke() { OnRoundPlanningStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу боя
    /// </summary>
    public static void RoundBattleStageEnterEventInvoke() { OnRoundBattleStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы боя
    /// </summary>
    public static void RoundBattleStageExitEventInvoke() { OnRoundBattleStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу расчетов
    /// </summary>
    public static void RoundCalculationStageEnterEventInvoke() { OnRoundCalculationStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы расчетов
    /// </summary>
    public static void RoundCalculationStageExitEventInvoke() { OnRoundCalculationStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу подбора соперников
    /// </summary>
    public static void RoundOpponentSelectionStageEnterEventInvoke() { OnRoundOpponentSelectionStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы подбора соперников
    /// </summary>
    public static void RoundOpponentSelectionStageExitEventInvoke() { OnRoundOpponentSelectionStageExit?.Invoke(); }
    #endregion

    #region МЕТОДЫ: Хранитель
    /// <summary>
    /// Приобретен опыт
    /// </summary>
    internal static void ExperiencePurchased(int experience) { OnKeeperExperiencePurchased?.Invoke(experience); }
    /// <summary>
    /// Изменилось количество опыта Хранителя (и, иногда, уровень лидерства)
    /// </summary>
    internal static void ExperienceChanged(int experience, int leadership) { OnExperienceChanged?.Invoke(experience, leadership); }
    /// <summary>
    /// Изменилось количество очков здоровья Хранителя
    /// </summary>
    internal static void KeeperHealthChanged(int health) { OnKeeperHealthChanged?.Invoke(health); }
    #endregion

    #region МЕТОДЫ: Отряд
    /// <summary>
    /// Изменилось количество героев в резерве
    /// </summary>
    /// <param name="count"></param>
    internal static void ReserveSizeChanged(int count) { OnReserveSizeChanged?.Invoke(count); }
    /// <summary>
    /// Изменилось количество героев во временном хранилище
    /// </summary>
    /// <param name="count"></param>
    internal static void TemporaryStorageSizeChanged(int count) { OnTemporaryStorageSizeChanged?.Invoke(count); }
    /// <summary>
    /// Изменилось количество героев на поле
    /// </summary>
    /// <param name="count"></param>
    internal static void HeroesOnTheFieldAmountChanged(int count) { OnHeroesOnTheFieldAmountChanged?.Invoke(count); }
    #endregion

    #region МЕТОДЫ UI матч
    /// <summary>
    /// Нажата кнопка "сменить стадию матча"
    /// </summary>
    internal static void ChangeMatchStageBttnPressed() { OnChangeMatchStageBttnPressed?.Invoke(); }
    #endregion

    #region МЕТОДЫ UI раунд
    /// <summary>
    /// Нажата кнопка: сменить фазу раунда
    /// </summary>
    public static void ChangeRoundStageBttnPressed() { OnChangeRoundStageBttnPressed?.Invoke(); }
    /// <summary>
    /// Нажата кнопка: купить опыт Хранителя
    /// </summary>
    public static void BuyExperienceBttnPressed() { OnBuyExperienceBttnPressed?.Invoke(); }
    /// <summary>
    /// Нажата кнопка: купить героя 
    /// </summary>
    internal static void BuyHero(Hero hero) { OnHeroPurchased?.Invoke(hero); }
    #endregion

    #region МЕТОДЫ: Инвентарь
    /// <summary>
    /// Изменилось количество монет
    /// </summary>
    /// <param name="coins"></param>
    internal static void CoinsAmountChanged(int coins) { OnCoinsAmountChanged?.Invoke(coins); }
    #endregion

}
