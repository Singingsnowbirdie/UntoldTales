//состояние

public interface IStage
{
    /// <summary>
    /// Название состояния
    /// </summary>
    string StageName { get; set; }

    /// <summary>
    /// Вход в состояние
    /// </summary>
    void Enter();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    void Exit();
}
