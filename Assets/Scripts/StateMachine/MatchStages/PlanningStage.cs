public class PlanningStage : MatchStage
{
    public PlanningStage(Match match)
    {
        currentRound = match.CurrentRound;
        StageName = "Фаза планирования";
    }

    /// <summary>
    /// Текущий раунд
    /// </summary>
    Round currentRound;
}
