using System.Collections;
using System.IO;
using UnityEngine;

//Круг героев
//Первый и последний этапы начальной стадии матча
//Первый этап: на время
//Последний этап: по очереди

public class HeroesCircleStage : IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Круг героев";

    /// <summary>
    /// Режим: по очереди?
    /// </summary>
    public bool IsQueueMode { get; set; }

    /// <summary>
    /// Круг героев (GO)
    /// </summary>
    GameObject heroesCircleGO;

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
        heroesCircleGO = UtilsManager.Spawn("TestObjects/HeroesCircle");      
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
