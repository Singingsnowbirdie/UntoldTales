using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Initial : StateMachine, IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Начальная стадия матча";

    /// <summary>
    /// Список игроков (передаем дальше)
    /// </summary>
    private readonly List<Player> players;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="players"></param>
    public MatchStage_Initial(List<Player> players)
    {
        this.players = players;
    }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        Initialize();
        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
        //устанавливаем начальное состояние
        SetStage(GetStage<HeroesCircleStage>());
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }

    public void Initialize()
    {
        //инициализируем состояния
        InitStages();
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    protected override void InitStages()
    {
        base.InitStages();
        //добавляем состояния
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage(this, players);
    }

    /// <summary>
    /// Меняет состояние стадии
    /// </summary>
    internal void ChangeStage()
    {
        if (CurrentStage is HeroesCircleStage)
        {
            CurrentStage.Exit();
        }
    }
}
