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

    #region ВХОД В СОСТОЯНИЕ
    internal static void OnStageEnterEventInvoke(string stage) { OnStageEnter?.Invoke(stage); }
    public static event Action<string> OnStageEnter;
    #endregion

    #region ВЫХОД ИЗ СОСТОЯНИЯ
    internal static void OnStageExitEventInvoke(string stage) { OnStageExit?.Invoke(stage); }
    public static event Action<string> OnStageExit;
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
