using System;
using System.Collections.Generic;
using UnityEngine;

//раунд

public class Round : IStage
{
    /// <summary>
    /// Все фазы раунда
    /// </summary>
    Dictionary<Type, IStage> roundStagesMap;

    /// <summary>
    /// Текущее состояние раунда
    /// </summary>
    IStage currentStage;

    public string StageName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Round()
    {
        InitStages();
        //SetStageByDefault();
    }

    /// <summary>
    /// Инициализатор фаз раунда
    /// </summary>
    void InitStages()
    {
        roundStagesMap = new Dictionary<Type, IStage>();
        roundStagesMap[typeof(RoundStage_Planning)] = new RoundStage_Planning();
        roundStagesMap[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        roundStagesMap[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        roundStagesMap[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();
    }

    /// <summary>
    /// Устанавливает следующую фазу (тест)
    /// </summary>
    internal void SetNextStage()
    {
        switch (currentStage.ToString())
        {
            case "RoundStage_Planning":
                SetStage_Battle();
                break;

            case "RoundStage_Battle":
                SetStage_Calculation();
                break;

            case "RoundStage_Calculation":
                SetStage_OpponentSelection();
                break;

            case "RoundStage_OpponentSelection":
                SetStage_Planning();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Включаем фазу
    /// </summary>
    void SetStage(IStage newStage)
    {
        //если сейчас активна другая фаза
        if (currentStage != null)
        {
            //выходим из нее
            currentStage.Exit();
        }
        //устанавливаем текущую фазу
        currentStage = newStage;
        //запускаем фазу
        currentStage.Enter();
    }

    /// <summary>
    /// Достаем нужную фазу из словаря
    /// </summary>
    IStage GetStage<T>() where T : IStage
    {
        var type = typeof(T);
        return roundStagesMap[type];
    }

    /// <summary>
    /// Устанавливает начальную фазу
    /// </summary>
    void SetStageByDefault()
    {
        SetStage_Planning();
    }

    /// <summary>
    /// Устанавливает фазу планирования
    /// </summary>
    public void SetStage_Planning()
    {
        SetStage(GetStage<RoundStage_Planning>());
    }

    /// <summary>
    /// Устанавливает фазу боя
    /// </summary>
    public void SetStage_Battle()
    {
        SetStage(GetStage<RoundStage_Battle>());
    }

    /// <summary>
    /// Устанавливает фазу расчетов
    /// </summary>
    public void SetStage_Calculation()
    {
        SetStage(GetStage<RoundStage_Calculation>());
    }

    /// <summary>
    /// Устанавливает фазу выбора противника
    /// </summary>
    public void SetStage_OpponentSelection()
    {
        SetStage(GetStage<RoundStage_OpponentSelection>());
    }

    public void Enter()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}
