using System;
using System.Collections.Generic;
using UnityEngine;

//раунд

public class Round : StateMachine, IStage
{

    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Раунд";

    public void Enter()
    {
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
    }

    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }

    /// <summary>
    /// Инициализатор 
    /// </summary>
    protected override void InitStages()
    {
        base.InitStages();

        //добавляем состояния
        Stages[typeof(RoundStage_Planning)] = new RoundStage_Planning();
        Stages[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        Stages[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        Stages[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();

        //устанавливаем начальное состояние
        SetStage(GetStage<RoundStage_Planning>());
    }
}
