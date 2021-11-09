//состояние

public interface IStage
{
    
    /// <summary>
    /// Вход в состояние
    /// </summary>
    void EnterStage();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    void ExitStage();
}
