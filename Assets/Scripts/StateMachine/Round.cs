using System;
using System.Collections.Generic;
using UnityEngine;

//Раунд. От этого класса наследуются PvE и PvP раунды

public abstract class Round : SMStage
{
    /// <summary>
    /// Название состояния
    /// </summary>
    string StageName { get; set; }

    public void Enter()
    {
        EventManager.OnStageEnterEventInvoke(StageName);
        Debug.Log($"Вход в стадию: {StageName}");

        //устанавливаем начальное состояние
        SetStage(FirstStage);
    }

    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(StageName);
        Debug.Log($"Выход из стадии: {StageName}");
    }

    public void InitializeStage()
    {
        StageName = "Раунд";
        //добавляем состояния
        //Stages[typeof(RoundStage_Planning)] = new RoundStage_Planning();
        //Stages[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        //Stages[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        //Stages[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();
    }
}
