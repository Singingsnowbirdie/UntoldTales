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
    /// Добавляет очки лидерства
    /// </summary>
    private void AddLeadership()
    {
        if (keeper.Leadership < keeper.MaxLeadership)
        {
            keeper.Leadership++;
            EventManager.LeadershipChanged(keeper.Leadership);
        }
    }

    /// <summary>
    /// Отнимает очки здоровья
    /// </summary>
    public void TakeAwayHealth(int points)
    {
        if (keeper.Health >= points)
        {
            keeper.Health -= points;
        }
        else
        {
            keeper.Health = 0;
        }
        EventManager.KeeperHealthChanged(keeper.Health);
        if (!CheckHealth())
        {
            EventManager.PlayerLose();
        }
    }

    /// <summary>
    /// Добавляет очки здоровья
    /// </summary>
    public void AddHealth(int points)
    {
        if (points <= keeper.MaxHealth - keeper.Health)
        {
            keeper.Health += points;
        }
        else
        {
            keeper.Health = keeper.MaxHealth;
        }
        EventManager.KeeperHealthChanged(keeper.Health);
    }

    /// <summary>
    /// Проверяет кол-во очков здоровья, оставшееся у Хранителя
    /// </summary>
    /// <returns></returns>
    public bool CheckHealth()
    {
        if (keeper.Health > 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Проверяет, достаточно ли очков лидерства, для приобретения еще одного юнита (героя)
    /// </summary>
    public bool IsEnoughLeadership(int amount)
    {
        if (keeper.Leadership <= amount) return true;
        else return false;
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    public override void Initialize()
    {
        keeper = new Keeper();

        //подписываемся на нажатие кнопки "купить очки лидерства"
        EventManager.OnBuyLeadershipBttnPressed += AddLeadership;
        //вызываем событие "хранитель инициализован"
        EventManager.KeeperInitialized();
    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnBuyLeadershipBttnPressed -= AddLeadership;
    }
}
