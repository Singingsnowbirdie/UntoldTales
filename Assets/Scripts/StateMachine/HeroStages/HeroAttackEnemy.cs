using UnityEngine;

public class HeroAttackEnemy : IStage
{
    private Hero hero;
    public string StageName { get; set; }


    public HeroAttackEnemy(Hero hero)
    {
        this.hero = hero;
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
        Debug.Log("атакую цель");
    }
}
