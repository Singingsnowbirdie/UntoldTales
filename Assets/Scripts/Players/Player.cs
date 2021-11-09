//От этого класса наследуются живой игрок и AI 

public abstract class Player
{
    public Player(int id)
    {
        ID = id;
        //подписываемся на вход в состояние
        EventManager.OnStageEnter += OnStageEnter;
        //подписываемся на выход из состояния
        EventManager.OnStageExit += OnStageExit;
    }

    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Герой, выбранный на круге героев
    /// </summary>
    public string SelectedHeroName { get; set; }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    protected virtual void OnStageEnter(IStage stage) { }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    protected virtual void OnStageExit(IStage stage) { }
}
