using System.Collections.Generic;
using UnityEngine;

public class PvERoundStage : RoundStage
{
    /// <summary>
    /// Счетчик сыгранных ПвЕ раундов
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Мобы
    /// </summary>
    List<Mob> mobs;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public override void Enter()
    {
        base.Enter();
    }

    protected override void Initialize()
    {
        StageName = "PvE Раунд";

        base.Initialize();

        //добавляем состояния
        Stages[typeof(PvERoundStage_Planning)] = new PvERoundStage_Planning();
        //Stages[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        //Stages[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        //Stages[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();

        //устанавливаем начальное состояние
        FirstStage = GetStage<PvERoundStage_Planning>();

        //создаем поле
        CreateField();

        //инициализируем мобов
        InitMobs();
    }

    /// <summary>
    /// Создаем поле 
    /// </summary>
    private void CreateField()
    {

    }

    /// <summary>
    /// Выбираем мобов, которых будем спавнить
    /// </summary>
    private void InitMobs()
    {
        //получаем ссылки на БД мобов
        List<Mob> meleeMobsDB = UtilsManager.GetMeleeMobsDB();
        List<Mob> rangeMobsDB = UtilsManager.GetRangeMobsDB();

        //инициализируем список мобов
        mobs = new List<Mob>();

        //добавляем трех ближников
        mobs.Add(meleeMobsDB[Random.Range(0, meleeMobsDB.Count)]);

        //если это второй из трех ПвЕ раундов
        if (Count == 2)
        {
            //добавляем двух дальников
            for (int i = 0; i < 2; i++)
            {
                mobs.Add(rangeMobsDB[Random.Range(0, rangeMobsDB.Count)]);
            }
        }
        //если это третий раунд
        else if (Count == 3)
        {
            //добавляем четырех дальников
            for (int i = 0; i < 4; i++)
            {
                mobs.Add(rangeMobsDB[Random.Range(0, rangeMobsDB.Count)]);
            }
        }
    }
}
