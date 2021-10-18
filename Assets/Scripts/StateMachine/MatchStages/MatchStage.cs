using UnityEngine;

//Cостояние матча

public abstract class MatchStage : IStage
{
    public string StageName { get; set; }

    public virtual void Enter()
    {
        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(StageName);
        Debug.Log($"Вход в стадию: {StageName}");
    }

    public virtual void Exit()
    {
        EventManager.OnStageExitEventInvoke(StageName);
        Debug.Log($"Выход из стадии: {StageName}");
    }
}
