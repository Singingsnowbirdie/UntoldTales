using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//раунд

public class NewBehaviourScript : MonoBehaviour
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
        behavioursMap[typeof(RoundBehaviourOpponentsSelection)] = new RoundBehaviourOpponentsSelection();
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
    IRoundBehaviour GetBehaviour<T>() where T:IRoundBehaviour
    {
        var type = typeof(T);
        return behavioursMap[type];
    }

    /// <summary>
    /// Устанавливает начальную фазу
    /// </summary>
    void SetBehaviourByDefault()
    {
        var behaviourByDefault = GetBehaviour<RoundBehaviourPlanning>();
        SetBehaviour(behaviourByDefault);
    }
}
