public class MatchController : IController
{
    /// <summary>
    /// Текущий матч
    /// </summary>
    public Match Match { get; set; }

    /// <summary>
    /// Инициализатор
    /// </summary>
    public void Initialize()
    {
        Match = new Match();
        Match.StartMatch();
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
    public void OnStart() { }
}
