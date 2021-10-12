using UnityEngine;

/// <summary>
/// состояние при котором герой ищет себе цель для атаки
/// </summary>
public class HeroSearchEnemy : IStage
{
    private Character character;
    private FindTarget findTarget;

    public HeroSearchEnemy(Character character)
    {
        this.character = character;
    }

    public void Enter()
    {
        SearchEnemy();
    }

    public void Exit()
    {
        // Debug.Log("HeroSearchEnemy выход");
    }

    public string StageName { get; set; }

    /// <summary>
    /// следующее состояние
    /// </summary>
    private void SetNextState()
    {
        if (character.CurrentTarget)
        {
               
            HeroMoveToEnemy aa = character.heroStateMachine.Stages[typeof(HeroMoveToEnemy)] as HeroMoveToEnemy;
            aa.pathfinding.target = character.CurrentTarget.gameObject;
            character.heroStateMachine.SetStage(character.heroStateMachine.Stages[typeof(HeroMoveToEnemy)]);
        } 
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void SearchEnemy()
    {
        if (character.CurrentTarget) {SetNextState(); return;} else Exit();

        Debug.Log("ищу цель");
        
        findTarget = new FindTarget();
        findTarget.FindNearestTarget(character);
    }
}
