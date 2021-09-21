using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : Controller
{
    /// <summary>
    /// Хранитель
    /// </summary>
    Keeper keeper;

    /// <summary>
    /// Конструктор
    /// </summary>
    public KeeperController()
    {
        keeper = new Keeper();
        EventManager.KeeperInitialized();

        //подписываемся на нажатие кнопки "купить очки лидерства"
        EventManager.OnBuyLeadershipBttnPressed += AddLeadership;

    }

    /// <summary>
    /// Добавляет очки лидерства
    /// </summary>
    private void AddLeadership()
    {
        if (keeper.Leadership < 10)
        {
            keeper.Leadership++;
            EventManager.LeadershipChanged(keeper.Leadership);
        }
    }

    /// <summary>
    /// Проверяет, достаточно ли очков лидерства, для приобретения еще одного юнита (героя)
    /// </summary>
    public bool IsEnoughLeadership(int amount)
    {
        if (keeper.Leadership <= amount) return true;
        else return false;
    }
}
