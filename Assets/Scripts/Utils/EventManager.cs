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
    //Игрок проиграл
    public static event Action OnPlayerLose;
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
    //Хранитель инициализирован
    public static event Action OnKeeperInitialized;
    // Изменилось количество очков лидерства
    public static event Action<int> OnLeadershipChanged;
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

    #region СОБЫТИЯ: UI 
    //Нажата кнопка "сменить фазу раунда"
    public static event Action OnChangeRoundStageBttnPressed;
    //Нажата кнопка "купить очки лидерства"
    public static event Action OnBuyLeadershipBttnPressed;
    //Изменилось количество монет у игрока
    public static event Action<int> OnCoinsAmountChanged;
    #endregion

    #region МЕТОДЫ: Матч
    /// <summary>
    /// Игрок проиграл (здоровье Хранителя опустилось ниже 0)
    /// </summary>
    internal static void PlayerLose() { throw new NotImplementedException(); }
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
    /// Хранитель инициализирован
    /// </summary>
    internal static void KeeperInitialized() { OnKeeperInitialized?.Invoke(); }

    /// <summary>
    /// Изменилось количество очков лидерства
    /// </summary>
    internal static void LeadershipChanged(int leadership) { OnLeadershipChanged?.Invoke(leadership); }
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

    #region МЕТОДЫ UI
    /// <summary>
    /// Нажата кнопка: сменить фазу раунда
    /// </summary>
    public static void ChangeRoundStage() { OnChangeRoundStageBttnPressed?.Invoke(); }
    /// <summary>
    /// Нажата кнопка: купить очки лидерства
    /// </summary>
    public static void BuyLeadership() { OnBuyLeadershipBttnPressed?.Invoke(); }
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
