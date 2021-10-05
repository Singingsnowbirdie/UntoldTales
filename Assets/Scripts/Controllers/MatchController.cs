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
        match.Initialize();
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
    public void OnStart() { }
}
