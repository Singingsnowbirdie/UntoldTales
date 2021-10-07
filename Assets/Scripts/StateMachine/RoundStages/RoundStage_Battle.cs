using UnityEngine;

public class RoundStage_Battle : IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Фаза раунда: бой";

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
