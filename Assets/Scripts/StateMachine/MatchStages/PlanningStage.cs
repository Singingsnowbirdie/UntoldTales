//стадия планирования

public class PlanningStage : MatchStage
{    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="match"></param>
    public PlanningStage(Match match)
    {
        this.match = match;
    }

    /// <summary>
    /// Текущий раунд
    /// </summary>
    Round round;

    /// <summary>
    /// матч
    /// </summary>
    private Match match;

    /// <summary>
    /// Создает раунд
    /// </summary>
    internal void CreateRound(bool isPvE, int pveRoundsFinished)
    {
        if (isPvE)
        {
            round = new PvERound(pveRoundsFinished);
        }
        else
        {
            round = new PvPRound();
        }

        match.CurrentRound = round;
    }

    /// <summary>
    /// Вход в стадию
    /// </summary>
    public override void EnterStage()
    {
        //создаем поле
        round.StartRound();
        //вызываем событие
        base.EnterStage();
    }
}
