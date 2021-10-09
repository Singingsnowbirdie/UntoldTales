using System;
using System.Collections.Generic;
using UnityEngine;

//Раунд. От этого класса наследуются PvE и PvP раунды

public abstract class Round : SMStage
{
    public override void Enter()
    {
        base.Enter();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}
