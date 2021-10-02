using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Final : IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Финальная стадия матча";

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
}
