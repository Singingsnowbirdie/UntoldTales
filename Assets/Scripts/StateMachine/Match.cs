using System.Collections.Generic;
using UnityEngine;

public class Match: StateMachine
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
    /// Инициализатор 
    /// </summary>
    internal void Initialize()
    {
        //инициализируем игроков
        InitPlayers();
        //инициализируем состояния
        InitStages();
    }

    /// <summary>
    /// Инициализатор состояний
    /// </summary>
    protected override void InitStages()
    {
        base.InitStages();
        //добавляем состояния
        Stages[typeof(MatchStage_Initial)] = new MatchStage_Initial(players);
        //Stages[typeof(MatchStage_Early)] = new MatchStage_Early();
        //Stages[typeof(MatchStage_Late)] = new MatchStage_Late();
        //Stages[typeof(MatchStage_Final)] = new MatchStage_Final();
    }

    /// <summary>
    /// Инициализатор игроков
    /// </summary>
    void InitPlayers()
    {
        //определяем список игроков
        players = new List<Player>
        {
            //добавляем "живого" игрока
            new Player(0)
        };
        //добавляем AI игроков
        for (int i = 1; i < maxPlayers; i++)
        {
            players.Add(new AIPlayer(i));
        }
    }

    /// <summary>
    /// Начинает матч
    /// </summary>
    internal void StartMatch()
    {
        //устанавливаем начальное состояние
        SetStage(GetStage<MatchStage_Initial>());
    }
}
