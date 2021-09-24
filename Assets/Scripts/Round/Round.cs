using System;
using System.Collections.Generic;
using UnityEngine;

//раунд

public class Round
{
    /// <summary>
    /// Все фазы раунда
    /// </summary>
    Dictionary<Type, IRoundStage> roundStagesMap;

    /// <summary>
    /// Текущее состояние раунда
    /// </summary>
    IRoundStage currentBehaviour;

    public Round()
    {
        InitBehaviours();
        SetBehaviourByDefault();
    }

    /// <summary>
    /// Инициализатор фаз раунда
    /// </summary>
    void InitBehaviours()
    {
        roundStagesMap = new Dictionary<Type, IRoundStage>();
        roundStagesMap[typeof(RoundStage_Planning)] = new RoundStage_Planning();
        roundStagesMap[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        roundStagesMap[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        roundStagesMap[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();
    }

    /// <summary>
    /// Устанавливает следующую фазу (тест)
    /// </summary>
    internal void SetNextBehaviour()
    {
        switch (currentBehaviour.ToString())
        {
            case "RoundBehaviourPlanning":
                SetBehaviourBattle();
                break;

            case "RoundBehaviourBattle":
                SetBehaviourCalculation();
                break;

            case "RoundBehaviourCalculation":
                SetBehaviourOpponentSelection();
                break;

            case "RoundBehaviourOpponentSelection":
                SetBehaviourPlanning();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Включаем фазу
    /// </summary>
    /// <param name="newBehaviour"></param>
    void SetBehaviour(IRoundStage newBehaviour)
    {
        //если сейчас активна другая фаза
        if (currentBehaviour != null)
        {
            //выходим из нее
            currentBehaviour.Exit();
        }
        //устанавливаем текущую фазу
        currentBehaviour = newBehaviour;
        //запускаем фазу
        currentBehaviour.Enter();
    }

    /// <summary>
    /// Достаем нужную фазу из словаря
    /// </summary>
    IRoundStage GetBehaviour<T>() where T : IRoundStage
    {
        var type = typeof(T);
        return roundStagesMap[type];
    }

    /// <summary>
    /// Устанавливает начальную фазу
    /// </summary>
    void SetBehaviourByDefault()
    {
        SetBehaviourPlanning();
    }

    private void Update()
    {
        //потому что Update не работает в классах, не унаследованных от MonoBehaviour
        if (currentBehaviour != null) currentBehaviour.Update();
    }

    /// <summary>
    /// Устанавливает фазу планирования
    /// </summary>
    public void SetBehaviourPlanning()
    {
        SetBehaviour(GetBehaviour<RoundStage_Planning>());
    }

    /// <summary>
    /// Устанавливает фазу боя
    /// </summary>
    public void SetBehaviourBattle()
    {
        SetBehaviour(GetBehaviour<RoundStage_Battle>());
    }

    /// <summary>
    /// Устанавливает фазу расчетов
    /// </summary>
    public void SetBehaviourCalculation()
    {
        SetBehaviour(GetBehaviour<RoundStage_Calculation>());
    }

    /// <summary>
    /// Устанавливает фазу выбора противника
    /// </summary>
    public void SetBehaviourOpponentSelection()
    {
        SetBehaviour(GetBehaviour<RoundStage_OpponentSelection>());
    }
}
