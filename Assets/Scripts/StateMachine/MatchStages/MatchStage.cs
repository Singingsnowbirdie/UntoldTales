using UnityEngine;

//Cостояние матча

public abstract class MatchStage : IStage
{
    public string StageName { get; set; }

    public virtual void EnterStage()
    {
        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(this);
        Debug.Log($"Вход в стадию: {this}");
    }

    public virtual void ExitStage()
    {
        EventManager.OnStageExitEventInvoke(this);
        Debug.Log($"Выход из стадии: {this}");
    }
}
