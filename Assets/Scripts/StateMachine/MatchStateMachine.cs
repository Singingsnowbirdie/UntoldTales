public class MatchStateMachine : StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public MatchStateMachine(Match match)
    {
        //состояния
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage(match);
        Stages[typeof(PlanningStage)] = new PlanningStage(match);
    }

    /// <summary>
    /// Запускает Круг Героев
    /// </summary>
    public void StartHeroesCircleStage(bool isTiming)
    {
        HeroesCircleStage stage = GetStage<HeroesCircleStage>() as HeroesCircleStage;
        //уточняем режим круга
        stage.IsTiming = isTiming;
        //Запускаем
        SetStage(stage);
    }

    /// <summary>
    /// Запускает фазу планирования
    /// </summary>
    internal void StartPlanningStage(bool isPvE, int pveRoundsFinished)
    {
        //выбираем стадию
        PlanningStage stage = GetStage<PlanningStage>() as PlanningStage;
        //передаем нужные значения
        stage.CreateRound(isPvE, pveRoundsFinished);
        //Запускаем
        SetStage(stage);
    }
}
