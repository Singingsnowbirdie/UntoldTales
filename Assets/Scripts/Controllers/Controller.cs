public interface IController
{
    /// <summary>
    /// Срабатывает после создания всех контроллеров и репозиториев
    /// </summary>
    void OnCreate();

    /// <summary>
    /// Этот метод будет инициализировать все контроллеры
    /// </summary>
    void Initialize();

    /// <summary>
    /// Срабатывает при старте
    /// </summary>
    void OnStart();

    /// <summary>
    /// срабатывает при выходе
    /// </summary>
    void OnExit();
}
