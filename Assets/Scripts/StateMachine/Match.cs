﻿using System.Collections.Generic;

public class Match : StateMachine
{
    /// <summary>
    /// Максимальное кол-во игроков
    /// </summary>
    readonly int maxPlayers = 8;

    /// <summary>
    /// Все игроки матча
    /// </summary>
    List<Player> players;

    /// <summary>
    /// Инициализатор стадий
    /// </summary>
    protected override void InitStages()
    {
        base.InitStages();

        //добавляем состояния
        Stages[typeof(MatchStage_Initial)] = new MatchStage_Initial();
        Stages[typeof(MatchStage_Early)] = new MatchStage_Early();
        Stages[typeof(MatchStage_Late)] = new MatchStage_Late();
        Stages[typeof(MatchStage_Final)] = new MatchStage_Final();

        //устанавливаем начальное состояние
        SetStage(GetStage<MatchStage_Initial>());
    }

    /// <summary>
    /// Инициализатор игроков 
    /// </summary>
    internal void InitPlayers()
    {
        players = new List<Player>();

        //сюда должны передаваться игроки из матчмейкера
    }
}
