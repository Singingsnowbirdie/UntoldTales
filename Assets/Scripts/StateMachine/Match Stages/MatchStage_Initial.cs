using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Initial : SMStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="players"></param>
    public MatchStage_Initial(List<Player> players)
    {
        this.players = players;
    }

    /// <summary>
    /// Список игроков
    /// </summary>
    private readonly List<Player> players;

    /// <summary>
    /// Сыграно PvE раундов
    /// </summary>
    private int pveRoundsPlayed;

    /// <summary>
    /// Инициализатор
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();
        Stages[typeof(HeroesCircleStage)] = new HeroesCircleStage(this, players);
        FirstStage = GetStage<HeroesCircleStage>();
        StageName = "Начальная стадия матча";
        pveRoundsPlayed = 0;
    }

    /// <summary>
    /// Меняет состояние стадии
    /// </summary>
    internal void ChangeStage()
    {
        if (CurrentStage is HeroesCircleStage)
        {

        }
    }
}
