//От этого класса наследуются живой игрок и AI 

public abstract class Player
{
    public Player(int id)
    {
        ID = id;
        //подписываемся на вход игры  в состояние
        EventManager.OnStageEnter += OnStageEnter;
        //подписываемся на выход игры из состояния
        EventManager.OnStageExit += OnStageExit;
    }

    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Герой, выбранный на круге героев
    /// </summary>
    public Hero SelectedHero { get; set; }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    protected virtual void OnStageEnter(string stage) { }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    protected virtual void OnStageExit(string stage) { }
}
