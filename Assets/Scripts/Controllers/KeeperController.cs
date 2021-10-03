using System;

public class KeeperController : IController
{
    /// <summary>
    /// Хранитель
    /// </summary>
    Keeper keeper;

    /// <summary>
    /// Проверяет, хватает ли опыта для повышения уровня лидерства
    /// </summary>
    private void CheckLeadership()
    {
        if (keeper.Experience >= 6)
        {
            keeper.Leadership = 2;
        }
        //сообщаем об изменении кол-ва опыта и лидерства
        EventManager.OnSomethingChangedEventInvoke(keeper.Experience, Changeables.Experience);
        EventManager.OnSomethingChangedEventInvoke(keeper.Leadership, Changeables.Leadership);
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
        EventManager.OnSomethingChangedEventInvoke(keeper.Health, Changeables.Health);
        if (!CheckHealth())
        {
            //игрок gроиграл
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
        EventManager.OnSomethingChangedEventInvoke(keeper.Health, Changeables.Health);
    }


    /// <summary>
    /// Инициализатор
    /// </summary>
    public void Initialize()
    {
        keeper = new Keeper();
    }

    public void OnExit()
    {
        EventManager.OnSomethingPurchased -= SomethingPurchased;
    }

    public void OnCreate()
    {
        EventManager.OnSomethingPurchased += SomethingPurchased;
    }

    /// <summary>
    /// Что-то куплено
    /// </summary>
    private void SomethingPurchased(int amount, Purchasables value)
    {
        if (value == Purchasables.Experience)
        {
            //добавляем опыт
            keeper.Experience += amount;
            //проверяем, хватает ли опыта для повышения уровня лидерства
            CheckLeadership();
        }
    }

    public void OnStart()
    {
        //throw new System.NotImplementedException();
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

}
