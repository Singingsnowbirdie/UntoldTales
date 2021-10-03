using System;
using System.Collections.Generic;

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
    protected Dictionary<Type, IStage> Stages { get; set; }

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
    }

    /// <summary>
    /// Включаем новое состояние
    /// </summary>
    protected void SetStage(IStage newStage)
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
