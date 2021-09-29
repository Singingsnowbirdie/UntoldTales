using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public Match()
    {
        InitStages();
        SetStageByDefault();
    }

    /// <summary>
    /// Максимальное кол-во игроков
    /// </summary>
    readonly int maxPlayers = 8;

    /// <summary>
    /// Все игроки матча
    /// </summary>
    List<Player> players;

    /// <summary>
    /// Все стадии
    /// </summary>
    Dictionary<Type, IMatchStage> matchStagesMap;

    /// <summary>
    /// Текущая стадия матча
    /// </summary>
    IMatchStage currentStage;

    /// <summary>
    /// Инициализатор стадий
    /// </summary>
    void InitStages()
    {
        matchStagesMap = new Dictionary<Type, IMatchStage>();
        matchStagesMap[typeof(MatchStage_Initial)] = new MatchStage_Initial();
        matchStagesMap[typeof(MatchStage_Early)] = new MatchStage_Early();
        matchStagesMap[typeof(MatchStage_Late)] = new MatchStage_Late();
        matchStagesMap[typeof(MatchStage_Final)] = new MatchStage_Final();
    }

    /// <summary>
    /// Устанавливает следующую стадию (тест)
    /// </summary>
    internal void SetNextStage()
    {
        switch (currentStage.ToString())
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
    /// Включаем стадию
    /// </summary>
    void SetStage(IMatchStage newStage)
    {
        //если сейчас активна другая стадия
        if (currentStage != null)
        {
            //выходим из нее
            currentStage.Exit();
        }
        //устанавливаем текущую стадию
        currentStage = newStage;
        //запускаем стадию
        currentStage.Enter();
    }

    /// <summary>
    /// Достаем нужную стадию из словаря
    /// </summary>
    IMatchStage GetStage<T>() where T : IMatchStage
    {
        var type = typeof(T);
        return matchStagesMap[type];
    }

    /// <summary>
    /// Устанавливает начальную фазу
    /// </summary>
    void SetStageByDefault()
    {
        SetStage_Initial();
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
}
