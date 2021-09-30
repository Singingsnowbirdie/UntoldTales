using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// Все состояния
    /// </summary>
    protected override Dictionary<Type, IStage> Stages { get; set; }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    protected override IStage CurrentStage { get; set; }

    /// <summary>
    /// Инициализатор стадий
    /// </summary>
    protected override void InitStages()
    {
        Stages = new Dictionary<Type, IStage>();
        Stages[typeof(MatchStage_Initial)] = new MatchStage_Initial();
        Stages[typeof(MatchStage_Early)] = new MatchStage_Early();
        Stages[typeof(MatchStage_Late)] = new MatchStage_Late();
        Stages[typeof(MatchStage_Final)] = new MatchStage_Final();
    }

    /// <summary>
    /// Устанавливает следующую стадию (тест)
    /// </summary>
    internal void SetNextStage()
    {
        switch (CurrentStage.ToString())
        {
            case "MatchStage_Initial":
                SetStage_Early();
                break;

            case "MatchStage_Early":
                SetStage_Late();
                break;

            case "MatchStage_Late":
                SetStage_Final();
                break;

            case "MatchStage_Final":
                SetStage_Initial();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Устанавливает начальную стадию
    /// </summary>
    private void SetStage_Initial()
    {
        SetStage(GetStage<MatchStage_Initial>());
    }

    /// <summary>
    /// Устанавливает раннюю стадию
    /// </summary>
    private void SetStage_Early()
    {
        SetStage(GetStage<MatchStage_Early>());
    }

    /// <summary>
    /// Устанавливает позднюю стадию
    /// </summary>
    private void SetStage_Late()
    {
        SetStage(GetStage<MatchStage_Late>());
    }

    /// <summary>
    /// Устанавливает финальную стадию
    /// </summary>
    private void SetStage_Final()
    {
        SetStage(GetStage<MatchStage_Final>());
    }

    /// <summary>
    /// Добавляет игроков (живых и ИИ) в список
    /// </summary>
    internal void AddPlayers()
    {
        //создаем список игроков
        players = new List<Player>();
        //заполняем его
        for (int i = 0; i < maxPlayers; i++)
        {
            players.Add(new Player(i));
        }
        //нулевым игроком определяем живого игрока
        players[0].IsAI = false;
    }

    /// <summary>
    /// Устанавливает стадию по умолчанию
    /// </summary>
    protected override void SetStageByDefault()
    {
        SetStage_Initial();
    }
}
