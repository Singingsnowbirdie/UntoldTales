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
    }

    public void Exit()
    {
        Debug.Log("выход");
    }

    /// <summary>
    /// следующее состояние
    /// </summary>
    private void SetNextState()
    {
        HeroMoveToEnemy heroSearchEnemy = Hero.heroStateMachine.Stages[typeof(HeroMoveToEnemy)] as HeroMoveToEnemy;
        heroSearchEnemy.Hero = Hero;
        if (Hero.CurrentTarget) Hero.heroStateMachine.SetStage(Hero.heroStateMachine.Stages[typeof(HeroMoveToEnemy)]);
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void SearchEnemy()
    {
        Hero.CurrentTarget = GameObject.Find("target").GetComponent<PassiveAbilityHero>();

        if(Hero.CurrentTarget) SetNextState(); else Exit();
    }
}
