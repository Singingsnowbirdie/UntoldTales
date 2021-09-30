using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : IController
{
    /// <summary>
    /// Текущий матч
    /// </summary>
    Match match;

    /// <summary>
    /// Инициализатор
    /// </summary>
    public void Initialize()
    {
        match = new Match();
    }

    /// <summary>
    /// При создании
    /// </summary>
    public void OnCreate()
    {
        EventManager.OnChangeMatchStageBttnPressed += ChangeMatchStage;
    }

    /// <summary>
    /// При выходе
    /// </summary>
    public void OnExit()
    {
        EventManager.OnChangeMatchStageBttnPressed -= ChangeMatchStage;
    }

    /// <summary>
    /// При старте
    /// </summary>
    public void OnStart()
    {
        match.AddPlayers();
    }

    /// <summary>
    /// Сменить стадию
    /// </summary>
    private void ChangeMatchStage()
    {
        match.SetNextStage();
    }
}
