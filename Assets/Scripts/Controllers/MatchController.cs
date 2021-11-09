using UnityEngine;

public class MatchController : IController
{
    /// <summary>
    /// Конструтор
    /// </summary>
    public MatchController()
    {
        match = new Match();
    }

    /// <summary>
    /// Матч
    /// </summary>
    public Match match;

    /// <summary>
    /// При старте
    /// </summary>
    public void OnStart() 
    {
        Debug.Log("Начало матча");
        match.StartMatch();
    }

    /// <summary>
    /// При выходе
    /// </summary>
    public void OnExit() { }
}
