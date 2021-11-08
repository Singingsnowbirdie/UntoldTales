using System;

public class PvERound : Round
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public PvERound(int pveRoundsFinished)
    {
        this.pveRoundsFinished = pveRoundsFinished;
    }

    /// <summary>
    /// Мобы
    /// </summary>
    Mobs mobs;

    /// <summary>
    /// Количество сыгранных ПвЕ раундов
    /// </summary>
    private int pveRoundsFinished;

    public override void StartRound()
    {
        //создаем поле
        base.StartRound();
        //создаем мобов
        CreateMobs();
    }

    /// <summary>
    /// Создает мобов и размещает на поле
    /// </summary>
    private void CreateMobs()
    {
        mobs = new Mobs(pveRoundsFinished, field.GetEnemyPoints());
    }
}
