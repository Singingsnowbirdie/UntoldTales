using System;
using System.Collections.Generic;

public class Match
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public Match()
    {
        Players = new Players();
        stateMachine = new MatchStateMachine(this);
    }

    /// </summary>
    /// Стейт-машина
    /// </summary>
    MatchStateMachine stateMachine;

    /// <summary>
    /// Круг героев 
    /// </summary>
    public HeroesCircle HeroesCircle { get; internal set; }

    /// <summary>
    /// Все игроки матча
    /// </summary>
    public Players Players { get; private set; }

    /// <summary>
    /// Сыграно PvE раундов
    /// </summary>
    int pveRoundsFinished;

    /// <summary>
    /// Текущий раунд
    /// </summary>
    public Round CurrentRound { get; internal set; }

    /// <summary>
    /// Начинает матч
    /// </summary>
    internal void StartMatch()
    {
        stateMachine.StartHeroesCircleStage(true);
    }

    /// <summary>
    /// Смена состояния
    /// </summary>
    /// <param name="currentStage"></param>
    internal void ChangeStage(HeroesCircleStage currentStage)
    {
        //при выходе из круга героев
        if (currentStage is HeroesCircleStage)
        {
            //запускаем стадию планирования
            stateMachine.StartPlanningStage(true, pveRoundsFinished);
        }
    }
}
