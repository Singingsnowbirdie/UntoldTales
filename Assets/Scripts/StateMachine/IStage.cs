//этот интерфейс должны реализовывать все состояния

public interface IStage
{
    /// <summary>
    /// Инициализатор состояния
    /// </summary>
    void Initialize(); 
    
    /// <summary>
    /// Вход в состояние
    /// </summary>
    void Enter();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    void Exit();
}
