using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvERound : Round
{
    protected override void Initialize()
    {
        StageName = "PvE Раунд";
        base.Initialize();
        Stages[typeof(PvERoundStage_Planning)] = new PvERoundStage_Planning();
        //Stages[typeof(RoundStage_Battle)] = new RoundStage_Battle();
        //Stages[typeof(RoundStage_Calculation)] = new RoundStage_Calculation();
        //Stages[typeof(RoundStage_OpponentSelection)] = new RoundStage_OpponentSelection();
        FirstStage = GetStage<PvERoundStage_Planning>();
    }
}
