using UnityEngine;

public class MatchController : IController
{
    /// <summary>
    /// Матч
    /// </summary>
    public Match match;

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
        Debug.Log("Начало матча");
        match.StartMatch();
    }
}
