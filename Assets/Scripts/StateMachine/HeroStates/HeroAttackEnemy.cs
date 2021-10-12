using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackEnemy : IStage
{
    private Hero hero;

    //отсчет времени
    private float attackCooldown = 0f;

    public HeroAttackEnemy(Hero hero)
    {
        this.hero = hero;
    }

    public string StageName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
        //счетчик до следующей атаки
        attackCooldown -= Time.deltaTime;

        if(attackCooldown <= 0)
        {
            Debug.Log("атакую цель");
            // HitTarget();

            hero.anim.SetTrigger("Attack");
            attackCooldown = 1f/ hero.attackSpeed;
        }
    }

    public void HitTarget()
    {
        hero.CurrentTarget.maxHealth--;
        Debug.Log("HitTarget");
    }
}
