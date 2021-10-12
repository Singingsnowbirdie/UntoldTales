using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : StateMachine 
{
    public HeroStateMachine(Character character)
    {
        InitStates(character);
    }

    private void InitStates(Character character)
    {
        Initialize();        
        Stages.Add(typeof(HeroSearchEnemy),new HeroSearchEnemy(character));
        Stages.Add(typeof(HeroMoveToEnemy),new HeroMoveToEnemy(character));
        Stages.Add(typeof(HeroAttackEnemy),new HeroAttackEnemy(character));
    }
}
