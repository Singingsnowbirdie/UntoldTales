using UnityEngine;

/// <summary>
/// состояние при котором герой ищет себе цель для атаки
/// </summary>
public class HeroSearchEnemy : IStage
{
    private Hero hero;
    private FindTarget findTarget;

    public string StageName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public HeroSearchEnemy(Hero hero)
    {
        this.hero = hero;
    }

    public void Enter()
    {
        SearchEnemy();
    }

    public void Exit()
    {
        // Debug.Log("HeroSearchEnemy выход");
    }

    /// <summary>
    /// следующее состояние
    /// </summary>
    private void SetNextState()
    {
        if (hero.CurrentTarget)
        {
               
            HeroMoveToEnemy aa = hero.heroStateMachine.Stages[typeof(HeroMoveToEnemy)] as HeroMoveToEnemy;
            aa.pathfinding.target = hero.CurrentTarget.gameObject;
            hero.heroStateMachine.SetStage(hero.heroStateMachine.Stages[typeof(HeroMoveToEnemy)]);
        } 
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void SearchEnemy()
    {
        if (hero.CurrentTarget) {SetNextState(); return;} else Exit();

        Debug.Log("ищу цель");
        
        findTarget = new FindTarget();
        findTarget.FindNearestTarget(hero);
    }
}
