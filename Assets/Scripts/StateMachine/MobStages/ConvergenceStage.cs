//Состояние моба: сближение с противником

public class ConvergenceStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mob"></param>
    public ConvergenceStage(Mob mob)
    {
        this.mob = mob;
    }
    
    /// <summary>
    /// Наименование состояния
    /// </summary>
    public string StageName { get; set; }

    /// <summary>
    /// Этот моб
    /// </summary>
    private readonly Mob mob;

    /// <summary>
    /// вход в состояние
    /// </summary>
    public void Enter() { }

    /// <summary>
    /// выход из состояния
    /// </summary>
    public void Exit() { }

}

