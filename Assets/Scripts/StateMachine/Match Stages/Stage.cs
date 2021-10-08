using UnityEngine;

//это состояние матча, которое не является стейт-машиной

public abstract class Stage : IStage
{
    public string StageName { get; set; }

    public virtual void Enter()
    {
        //инициализируем
        Initialize();

        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(StageName);
        Debug.Log($"Вход в стадию: {StageName}");
    }

    public virtual void Exit()
    {
        EventManager.OnStageExitEventInvoke(StageName);
        Debug.Log($"Выход из стадии: {StageName}");
    }

    public abstract void Initialize();
}
