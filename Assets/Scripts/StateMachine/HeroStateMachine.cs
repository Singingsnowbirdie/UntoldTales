using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : StateMachine 
{
    public HeroStateMachine(Hero hero)
    {
        InitStates(hero);
    }

    private void InitStates(Hero hero)
    {
        Initialize();        
        Stages.Add(typeof(HeroSearchEnemy),new HeroSearchEnemy(hero));
        Stages.Add(typeof(HeroMoveToEnemy),new HeroMoveToEnemy(hero));
        Stages.Add(typeof(HeroAttackEnemy),new HeroAttackEnemy(hero));
    }
}
