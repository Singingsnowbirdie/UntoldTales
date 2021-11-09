//состояние

public interface IStage
{
    /// <summary>
    /// Название состояния
    /// Это временное свойство
    /// Будет выпилено в релизе
    /// Где нужно -заполнять
    /// Где не нужно - реализовывать пустышкой и забывать
    /// </summary>
    string StageName { get; set; }

    /// <summary>
    /// Вход в состояние
    /// </summary>
    void EnterStage();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    void ExitStage();
}
