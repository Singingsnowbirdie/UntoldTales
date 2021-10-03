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
        match.InitPlayers();
        match.StartMatch();
    }

    /// <summary>
    /// При создании
    /// </summary>
    public void OnCreate() { }


    /// <summary>
    /// При выходе
    /// </summary>
    public void OnExit() { }

    /// <summary>
    /// При старте
    /// </summary>
    public void OnStart()
    {
    }
}
