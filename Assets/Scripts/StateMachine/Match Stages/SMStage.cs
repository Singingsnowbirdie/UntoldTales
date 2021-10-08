
//это состояние матча, которое одновременно является стейтмашиной 

using UnityEngine;

public abstract class SMStage : StateMachine, IStage
{
    /// <summary>
    /// Название состояния
    /// </summary>
    public string StageName { get; set; }
    
    /// <summary>
    /// Вход в состояние
    /// </summary>
    public virtual void Enter()
    {
        //инициализируем
        Initialize();

        //устанавливаем начальное состояние
        SetStage(FirstStage);

        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(StageName);
        Debug.Log($"Вход в стадию: {StageName}");
    }

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(StageName);
        Debug.Log($"Выход из стадии: {StageName}");
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}
