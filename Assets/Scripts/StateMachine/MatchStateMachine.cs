using System;

public class MatchStateMachine : StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="match"></param>
    public MatchStateMachine(Match match)
    {
        InitStages(match);
    }

    /// <summary>
    /// Инициализация состояний
    /// </summary>
    private void InitStages(Match match)
    {
        //добавляем состояния
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage(match);
        Stages[typeof(PlanningStage)] = new PlanningStage(match);
    }
    
    /// <summary>
    /// Запускает Круг Героев
    /// </summary>
    public void StartHeroesCircleStage()
    {
        SetStage(GetStage<HeroesCircleStage>());
    }

    /// <summary>
    /// Запускает фазу планирования
    /// </summary>
    internal void StartPlanningStage()
    {
        SetStage(GetStage<HeroesCircleStage>());
    }
}
