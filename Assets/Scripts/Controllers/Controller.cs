public interface IController
{
    /// <summary>
    /// Срабатывает при старте
    /// </summary>
    void OnStart();

    /// <summary>
    /// срабатывает при выходе
    /// </summary>
    void OnExit();
}
