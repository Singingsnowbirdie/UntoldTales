using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : Controller
{
    /// <summary>
    /// Банк (хранит монеты)
    /// </summary>
    Bank bank;

    /// <summary>
    /// Стоимость единицы опыта (в монетах)
    /// </summary>
    readonly int ExperienceСost = 1;

    /// <summary>
    /// Количество единиц опыта, приобретаемых за 1 раз
    /// Пока ридонли, потом возможно это количеество сможет меняться, тогда уберем этот модификатор
    /// </summary>
    readonly int ExperiencePurchasedForOnce = 2;

    public override void Initialize()
    {
        base.Initialize();
        bank = new Bank();
        //подписываемся на нажатие кнопки "купить опыт Хранителя"
        EventManager.OnBuyExperienceBttnPressed += BuyExperience;
    }

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
            EventManager.ExperiencePurchased(ExperiencePurchasedForOnce);
        }
    }

    /// <summary>
    /// На старте
    /// </summary>
    public override void OnStart()
    {
        base.OnStart();
        bank.SetStartCoinsAmount();
    }

    public override void OnExit()
    {
        EventManager.OnBuyExperienceBttnPressed -= BuyExperience;
    }
}
