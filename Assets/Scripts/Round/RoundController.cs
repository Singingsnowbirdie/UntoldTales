

/// <summary>
/// Контроллер раунда
/// </summary>
internal class RoundController : Controller
{
    /// <summary>
    /// Раунд
    /// </summary>
    Round round;

    /// <summary>
    /// При старте
    /// </summary>
    public override void OnStart()
    {
        base.OnStart();
        round = new Round();
    }
}