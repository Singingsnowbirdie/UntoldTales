using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackEnemy : IStage
{
    public void Enter()
    {
        Attack();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    private void Attack()
    {
        Debug.Log("атакую цель");
    }
}
