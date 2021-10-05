using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Initial : StateMachine, IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Начальная стадия матча";

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
        //инициализируем состояния
        InitStages();
        //устанавливаем начальное состояние
        SetStage(GetStage<HeroesCircleStage>());
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    protected override void InitStages()
    {
        base.InitStages();
        //добавляем состояния
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage();
        Debug.Log($"Инициализация состояний: {stageName}");
    }
}
