using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : Controller
{
    public override void Initialize()
    {
        base.Initialize();
        //подписка на событие: "начало фазы боя"
        EventManager.OnRoundBattleStageEnter += StartBattle;
        //подписка на событие: "конец фазы боя"
        EventManager.OnRoundBattleStageExit += EndBattle;
    }

    /// <summary>
    /// Название можно поменять
    /// Выводит героя из боя
    /// </summary>
    private void EndBattle()
    {

    }

    /// <summary>
    /// Название можно поменять
    /// Запускает состояние "в бою"
    /// </summary>
    private void StartBattle()
    {

    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnRoundBattleStageEnter -= StartBattle;
        EventManager.OnRoundBattleStageExit -= EndBattle;
    }
}
