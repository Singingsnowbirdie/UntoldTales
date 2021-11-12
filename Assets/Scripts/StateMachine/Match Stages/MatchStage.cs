using UnityEngine;

//Cостояние матча

public abstract class MatchStage : IStage
{
    public string StageName { get; set; }

    public virtual void EnterStage()
    {
        Debug.Log($"Вход в стадию: {this}");
        EventManager.OnStageEnterEventInvoke(this);
    }

    public virtual void ExitStage()
    {
        Debug.Log($"Выход из стадии: {this}");
        EventManager.OnStageExitEventInvoke(this);
    }
}
