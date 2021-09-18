using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//раунд

public class RoundController : Controller
{
    /// <summary>
    /// Все фазы раунда
    /// </summary>
    Dictionary<Type, IRoundBehaviour> behavioursMap;

    /// <summary>
    /// Текущее состояние раунда
    /// </summary>
    IRoundBehaviour currentBehaviour;

    private void Start()
    {
        InitBehaviours();
        SetBehaviourByDefault();
    }

    /// <summary>
    /// Инициализатор фаз раунда
    /// </summary>
    void InitBehaviours()
    {
        behavioursMap = new Dictionary<Type, IRoundBehaviour>();
        behavioursMap[typeof(RoundBehaviourPlanning)] = new RoundBehaviourPlanning();
        behavioursMap[typeof(RoundBehaviourBattle)] = new RoundBehaviourBattle();
        behavioursMap[typeof(RoundBehaviourCalculation)] = new RoundBehaviourCalculation();
        behavioursMap[typeof(RoundBehaviourOpponentSelection)] = new RoundBehaviourOpponentSelection();
    }

    /// <summary>
    /// Включаем фазу
    /// </summary>
    /// <param name="newBehaviour"></param>
    void SetBehaviour(IRoundBehaviour newBehaviour)
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
    IRoundBehaviour GetBehaviour<T>() where T : IRoundBehaviour
    {
        var type = typeof(T);
        return behavioursMap[type];
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
        SetBehaviour(GetBehaviour<RoundBehaviourPlanning>());
    }

    /// <summary>
    /// Устанавливает фазу боя
    /// </summary>
    public void SetBehaviourBattle()
    {
        SetBehaviour(GetBehaviour<RoundBehaviourBattle>());
    }

    /// <summary>
    /// Устанавливает фазу расчетов
    /// </summary>
    public void SetBehaviourCalculation()
    {
        SetBehaviour(GetBehaviour<RoundBehaviourCalculation>());
    }

    /// <summary>
    /// Устанавливает фазу выбора противника
    /// </summary>
    public void SetBehaviourOpponentSelection()
    {
        SetBehaviour(GetBehaviour<RoundBehaviourOpponentSelection>());
    }
}
