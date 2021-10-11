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
        Stages[typeof(PvERoundStage)] = new PvERoundStage();
        FirstStage = GetStage<HeroesCircleStage>();
        StageName = "Начальная стадия матча";
        pveRoundsPlayed = 0;
    }

    /// <summary>
    /// Меняет состояние стадии
    /// </summary>
    internal void ChangeStage()
    {
        //если завершаем круг героев
        if (CurrentStage is HeroesCircleStage)
        {
            //запускаем ПвЕ раунд 
            SetStage(GetStage<PvERoundStage>());
        }
        //если завершаем ПвЕ раунд
        else if (CurrentStage is PvERoundStage)
        {
            //нужно проверять, сколько их уже отыграно
            if (pveRoundsPlayed == 0)
            {
                //запускаем ПвЕ раунд 
                SetStage(GetStage<PvERoundStage>());
                //собщаем раунду, какой он по счету в серии
                (CurrentStage as PvERoundStage).Count = 1;
                //увеличиваем счетчик
                pveRoundsPlayed++;
            }
            else if (pveRoundsPlayed == 1)
            {
                //запускаем ПвЕ раунд 
                SetStage(GetStage<PvERoundStage>());
                //собщаем раунду, какой он по счету в серии
                (CurrentStage as PvERoundStage).Count = 2;
                //увеличиваем счетчик
                pveRoundsPlayed++;
            }
            else if (pveRoundsPlayed == 2)
            {
                //запускаем ПвЕ раунд 
                SetStage(GetStage<PvERoundStage>());
                //собщаем раунду, какой он по счету в серии
                (CurrentStage as PvERoundStage).Count = 3;
                //увеличиваем счетчик
                pveRoundsPlayed++;
            }
            else if (pveRoundsPlayed == 3)
            {
                //выходим из серии ПвЕ раундов
            }
        }
    }
}
