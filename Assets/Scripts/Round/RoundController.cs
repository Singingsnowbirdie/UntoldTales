﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RoundController : Controller
{
    /// <summary>
    /// Раунд
    /// </summary>
    Round round;

    /// <summary>
    /// Конструктор
    /// </summary>
    public RoundController()
    {
        round = new Round();
        EventManager.OnChangeRoundStageBttnPressed += ChangeRoundStage;
    }

    /// <summary>
    /// Сменить фазу раунда
    /// </summary>
    private void ChangeRoundStage()
    {
        round.SetNextBehaviour();
    }

    private void OnDestroy()
    {
        EventManager.OnChangeRoundStageBttnPressed -= ChangeRoundStage;
    }
}
