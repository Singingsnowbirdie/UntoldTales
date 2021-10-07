using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackEnemy : IStage
{
    private Hero hero;

    public HeroAttackEnemy(Hero hero)
    {
        this.hero = hero;
    }

    public void Enter()
    {
        Attack();
    }

    public void Exit()
    {
        // Debug.Log("HeroAttackEnemy выход");
    }

    private void Attack()
    {
        Debug.Log("атакую цель");
    }
}
