using UnityEngine;

/// <summary>
/// состояние при котором герой ищет себе цель для атаки
/// </summary>
public class HeroSearchEnemy : IStage
{
    public Hero Hero;

    public void Enter()
    {
        SearchEnemy();
        Exit();
    }

    public void Exit()
    {
        
    }

    /// <summary>
    /// следующее состояние
    /// </summary>
    private void SetNextState()
    {
        if (Hero.CurrentTarget) Hero.heroStateMachine.SetStage(Hero.heroStateMachine.Stages[typeof(HeroAttackEnemy)]);
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void SearchEnemy()
    {
        Hero.CurrentTarget = GameObject.Find("target").GetComponent<PassiveAbilityHero>();
        Debug.Log("цель найдена " + GameObject.Find("target").GetComponent<PassiveAbilityHero>());
        SetNextState();
    }
}
