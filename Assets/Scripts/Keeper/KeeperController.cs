public class KeeperController : Controller
{
    /// <summary>
    /// Хранитель
    /// </summary>
    Keeper keeper;

    /// <summary>
    /// Добавляет очки опыта
    /// </summary>
    private void AddExperience(int amount)
    {
        //добавляем опыт
        keeper.Experience += amount;
        //проверяем, хватает ли опыта для повышения уровня лидерства
        CheckLeadership();
    }

    /// <summary>
    /// Проверяет, хватает ли опыта для повышения уровня лидерства
    /// </summary>
    private void CheckLeadership()
    {
        if (keeper.Experience >= 6)
        {
            keeper.Leadership = 2;
        }
        //сообщаем об изменении кол-ва опыта и лидерства (делаем это одним событием, чтоб сэкономить вызовы)
        EventManager.ExperienceChanged(keeper.Experience, keeper.Leadership);
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
            //игрок кроиграл
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
    /// Инициализатор
    /// </summary>
    public override void Initialize()
    {
        keeper = new Keeper();

        //подписываемся на покупку опыта
        EventManager.OnKeeperExperiencePurchased += AddExperience;
    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnKeeperExperiencePurchased -= AddExperience;
    }
}
