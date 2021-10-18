public class Match
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public Match()
    {
        //создаем игроков
        players = new Players();
        //создаем круг героев
        heroesCircle = UtilsManager.Spawn("TestObjects/HeroesCircle").GetComponent<HeroesCircle>();
        //создаем экземпляр машины состояний
        stateMachine = new MatchStateMachine(this);
    }

    /// </summary>
    /// состояния
    /// </summary>
    MatchStateMachine stateMachine;

    /// <summary>
    /// Все игроки матча
    /// </summary>
    Players players;
    internal Players Players { get => players; }

    /// <summary>
    /// Сыграно PvE раундов
    /// </summary>
    private int pveRoundsCounter;

    /// <summary>
    /// Текущий раунд
    /// </summary>
    Round currentRound;

    /// <summary>
    /// Кгуг героев
    /// </summary>
    private HeroesCircle heroesCircle;
    public HeroesCircle HeroesCircle { get => heroesCircle;}

    public Round CurrentRound { get => currentRound; }

    /// <summary>
    /// Начинает матч
    /// </summary>
    internal void StartMatch()
    {
        //запускаем первый круг героев
        stateMachine.StartHeroesCircleStage();
    }

    /// <summary>
    /// Меняет состояние на следующее
    /// </summary>
    public void ChangeStage()
    {
        //если завершается Круг Героев
        if (stateMachine.CurrentStage is HeroesCircleStage)
        {
            //создаем новый раунд
            currentRound = new PvERound(pveRoundsCounter);
            //увеличиваем счетчик
            pveRoundsCounter++;
            //запускаем стадию планирования
            stateMachine.StartPlanningStage();
        }
    }
}
