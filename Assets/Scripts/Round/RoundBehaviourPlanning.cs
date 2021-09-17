using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBehaviourPlanning : IRoundBehaviour
{
    public void Enter()
    {
        //разрешаем покупать опыт Хранителя (и повышать его уровень)
        //разрешаем покупать героев
        //разрешаем продавать героев
        //разрешаем расставлять героев на игровом поле
        //разрешаем снаряжать героев

        EventManager.RoundPlanningStateEnterEventInvoke();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
