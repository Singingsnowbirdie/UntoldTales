using UnityEngine;

public class HeroAttackEnemy : IStage
{
    private Character character;
    public string StageName { get; set; }


    //отсчет времени
    private float attackCooldown = 0f;

    public HeroAttackEnemy(Character character)
    {
        this.character = character;
    }

    public void EnterStage()
    {
        Attack();
    }

    public void ExitStage()
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

            character.anim.SetTrigger("Attack");
            attackCooldown = 1f/ character.attackSpeed;
        }
    }

    public void HitTarget()
    {
        character.CurrentTarget.maxHealth--;
        Debug.Log("HitTarget");
    }
}
