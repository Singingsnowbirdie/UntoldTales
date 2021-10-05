using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    public AIPlayer(int id) : base(id) { }

    protected override void OnStageEnter(string stage)
    {
        //Круг героев
        if (stage == "HeroesCircleStage")
        {
            //выбираем героя
            SelectHero();
        }
    }

    private void SelectHero()
    {

    }
}
