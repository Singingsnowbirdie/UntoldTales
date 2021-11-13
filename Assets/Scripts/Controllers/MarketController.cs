using System;

public class MarketController : IController
{
    public MarketController()
    {
        bank = new Bank();
    }

    /// <summary>
    /// Банк (хранит монеты)
    /// </summary>
    Bank bank;

    /// <summary>
    /// Стоимость единицы опыта (в монетах)
    /// </summary>
    readonly int ExperienceСost = 1;

    /// <summary>
    /// Стоимость обновления ассортимента в магазине
    /// </summary>
    int MarketRefreshingCost = 2;

    /// <summary>
    /// Количество единиц опыта, приобретаемых за 1 раз
    /// </summary>
    readonly int ExperiencePurchasedForOnce = 2;

    /// <summary>
    /// Покупка опыта Хранителя
    /// </summary>
    private void BuyExperience()
    {
        int transfer = ExperienceСost * ExperiencePurchasedForOnce;
        //если монет достаточно для покупки опыта
        if (bank.IfEnoughCoins(transfer))
        {
            //тратим
            bank.SpendCoins(transfer);
            //сообщаем о покупке
            EventManager.OnSomethingChangedEventInvoke(ExperiencePurchasedForOnce, Changeable.Experience);
        }
    }

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
            RefreshMarket();
        }
    }

    /// <summary>
    /// Выбирает героев для показа в магазине
    /// </summary>
    private void RefreshMarket()
    {

    }

    /// <summary>
    /// Нажата какая-то кнопка
    /// </summary>
    /// <param name="obj"></param>
    private void BttnPressed(Bttn bttn)
    {
        //нажата кнопка обновления ассортимента магазина
        if (bttn == Bttn.RefreshMarketBttn)
        {
            //если хватает денег
            if (bank.IfEnoughCoins(MarketRefreshingCost))
            {
                //тратим монетки
                bank.SpendCoins(MarketRefreshingCost);
                //обновляем ассортимент
                RefreshMarket();
            }
        }
    }
}
