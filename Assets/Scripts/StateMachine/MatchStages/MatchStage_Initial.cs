using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Initial : StateMachine, IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Начальная стадия матча";

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }

    //все состояния
    protected override Dictionary<Type, IStage> Stages { get; set; }

    //текущее состояние
    protected override IStage CurrentStage { get; set; }

    /// <summary>
    /// Инициализатор этапов
    /// </summary>
    protected override void InitStages()
    {
        Stages = new Dictionary<Type, IStage>();
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage();
    }

    /// <summary>
    /// Устанавливаем начальное состояние
    /// </summary>
    protected override void SetStageByDefault()
    {
        SetStage_HeroesCircle(false);
    }

    /// <summary>
    /// Запускает Круг Героев
    /// </summary>
    private void SetStage_HeroesCircle(bool isQueueMode)
    {
        SetStage(GetStage<HeroesCircleStage>());
        (CurrentStage as HeroesCircleStage).IsQueueMode = isQueueMode;
    }

}
