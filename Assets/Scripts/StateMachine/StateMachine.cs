using System;
using System.Collections.Generic;

public abstract class StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    protected StateMachine()
    {
        //инициализировать состояния
        InitStages();
        //установить начальное состояние
        SetStageByDefault();
    }

    /// <summary>
    /// Все состояния
    /// </summary>
    protected abstract Dictionary<Type, IStage> Stages { get; set; }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    protected abstract IStage CurrentStage { get; set; }

    /// <summary>
    /// Инициализатор состояний
    /// </summary>
    protected abstract void InitStages();

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

    /// <summary>
    /// Устанавливает начальную фазу
    /// </summary>
    protected abstract void SetStageByDefault();
}
