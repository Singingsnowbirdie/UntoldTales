using System.Collections.Generic;

public class Match: StateMachine
{
    /// <summary>
    /// Максимальное кол-во игроков
    /// </summary>
    readonly int maxPlayers = 8;

    /// <summary>
    /// Все игроки матча
    /// </summary>
    List<Player> players;

    /// <summary>
    /// Создает список игроков
    /// </summary>
    /// <returns></returns>
    private List<Player> CreatePlayers()
    {
        List<Player> players = new List<Player>
        {
            new RealPlayer(0)
        };
        //добавляем AI игроков
        for (int i = 1; i < maxPlayers; i++)
        {
            players.Add(new AIPlayer(i));
        }
        return players;

    }

    /// <summary>
    /// Начинает матч
    /// </summary>
    internal void StartMatch()
    {
        //инициализируем
        Initialize();
        //устанавливаем начальное состояние
        SetStage(FirstStage);
    }

    /// <summary>
    /// Инициализатор 
    /// </summary>
    protected override void Initialize()
    {
        //инициализируем игроков
        players = CreatePlayers();

        base.Initialize();

        //добавляем состояния
        Stages[typeof(MatchStage_Initial)] = new MatchStage_Initial(players);
        //Stages[typeof(MatchStage_Early)] = new MatchStage_Early();
        //Stages[typeof(MatchStage_Late)] = new MatchStage_Late();
        //Stages[typeof(MatchStage_Final)] = new MatchStage_Final();

        //устанавливаем начальное
        FirstStage = GetStage<MatchStage_Initial>();
    }
}
