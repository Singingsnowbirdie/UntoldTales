using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : Controller
{
    /// <summary>
    /// Количество монет у игрока
    /// </summary>
    int coins;

    public override void Initialize()
    {
        //подписываемся на изменение количества монет
        EventManager.OnCoinsAmountChanged += CheckCoinsAmount;
    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnCoinsAmountChanged -= CheckCoinsAmount;
    }

    private void CheckCoinsAmount(int obj)
    {
        throw new NotImplementedException();
    }
}
