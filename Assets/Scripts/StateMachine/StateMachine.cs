using System;
using System.Collections.Generic;

public abstract class StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    protected StateMachine()
    {
        Stages = new Dictionary<Type, IStage>();
    }

    /// <summary>
    /// Все состояния
    /// </summary>
    public Dictionary<Type, IStage> Stages { get; set; }

    /// <summary>
    /// Начальное состояние
    /// </summary>
    public IStage FirstStage { get; set; }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    public IStage CurrentStage { get; set; }

    /// <summary>
    /// Включаем новое состояние
    /// </summary>
    public void SetStage(IStage newStage)
    {
        //запоминаем текущую стадию
        CurrentStage = newStage;
        //запускаем ее
        CurrentStage.EnterStage();
    }

    /// <summary>
    /// Достаем нужную стадию из словаря
    /// </summary>
    public IStage GetStage<T>() where T : IStage
    {
        var type = typeof(T);
        return Stages[type];
    }
}
