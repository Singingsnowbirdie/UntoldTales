using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    protected StateMachine()
    {
        InitStages();
    }

    /// <summary>
    /// Все состояния
    /// </summary>
    public Dictionary<Type, IStage> Stages { get; set; }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    protected IStage CurrentStage { get; set; }

    /// <summary>
    /// Инициализатор состояний
    /// </summary>
    protected virtual void InitStages()
    {
        Stages = new Dictionary<Type, IStage>();
        //добавляем состояния
        // Stages.Add(typeof(HeroSearchEnemy),new HeroSearchEnemy());
        // Stages.Add(typeof(HeroMoveToEnemy),new HeroMoveToEnemy());
        // Stages.Add(typeof(HeroAttackEnemy),new HeroAttackEnemy());
    }

    /// <summary>
    /// Включаем новое состояние
    /// </summary>
    public void SetStage(IStage newStage)
    {
        //если сейчас активна другая стадия
        if (CurrentStage != null)
        {
            //выходим из нее
            CurrentStage.Exit();
        }
        //устанавливаем текущую стадию
        CurrentStage = newStage;
        //запускаем стадию
        CurrentStage.Enter();
    }

    /// <summary>
    /// Достаем нужную стадию из словаря
    /// </summary>
    protected IStage GetStage<T>() where T : IStage
    {
        var type = typeof(T);
        return Stages[type];
    }
}
