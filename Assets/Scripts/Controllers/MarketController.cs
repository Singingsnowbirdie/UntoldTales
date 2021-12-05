//Магазин

using System.Collections.Generic;

public class MarketController : IController
{
    public MarketController()
    {
        bank = new Bank();
    }

    /// <summary>
    /// Банк (хранит монеты)
    /// </summary>
    readonly Bank bank;

    /// <summary>
    /// Сцена
    /// </summary>
    public static MatchScene Scene { get; internal set; }

    #region ПОКУПКА ГЕРОЯ
    #endregion

    #region ОБНОВЛЕНИЕ АССОРТИМЕНТА
    /// <summary>
    /// Стоимость обновления ассортимента в магазине
    /// </summary>
    readonly int AssortmentUpdatingCost = 2;

    /// <summary>
    /// Обновляет ассортимент магазина
    /// </summary>
    private void UpdateAssortment()
    {
        //создаем новый список
        List<CharacterInfo> heroes = new List<CharacterInfo>();

        //заполняем его

        //сообщаем панельке магазина, что нужно отобразить новый набор героев
        EventManager.OnMarketAssortmentChangedEventInvoke(heroes);
    }
    #endregion

    #region ПОКУПКА ОПЫТА
    /// <summary>
    /// Стоимость единицы опыта (в монетах)
    /// </summary>
    readonly int ExperienceСost = 1;

    /// <summary>
    /// Количество единиц опыта, приобретаемых за 1 раз
    /// </summary>
    readonly int ExperiencePurchasedForOnce = 2;

    /// <summary>
    /// Покупка опыта Хранителя
    /// </summary>
    private void BuyExperience()
    {
        //если монет достаточно для покупки опыта
        if (bank.IfEnoughCoins(ExperienceСost))
        {
            //тратим
            bank.SpendCoins(ExperienceСost);
            //сообщаем о покупке
            EventManager.OnSomethingChangedEventInvoke(ExperiencePurchasedForOnce, Changeable.Experience);
        }
    }
    #endregion

    /// <summary>
    /// На старте
    /// </summary>
    public void OnStart()
    {
        bank.SetStartCoinsAmount();
        EventManager.OnBttnPressed += BttnPressed;
        EventManager.OnStageEnter += StageEnter;
    }

    /// <summary>
    /// При выходе
    /// </summary>
    public void OnExit()
    {
        EventManager.OnBttnPressed -= BttnPressed;
        EventManager.OnStageEnter -= StageEnter;
    }

    private void StageEnter(IStage stage)
    {
        //в начале стадии планирования
        if (stage is PlanningStage)
        {
            UpdateAssortment();
        }
    }

    /// <summary>
    /// Нажата какая-то кнопка
    /// </summary>
    /// <param name="obj"></param>
    private void BttnPressed(Bttn bttn)
    {
        //нажата кнопка обновления ассортимента магазина
        if (bttn == Bttn.UpdateAssortmentBttn)
        {
            //если хватает денег
            if (bank.IfEnoughCoins(AssortmentUpdatingCost))
            {
                //тратим монетки
                bank.SpendCoins(AssortmentUpdatingCost);
                //обновляем ассортимент
                UpdateAssortment();
            }
        }
    }
}
