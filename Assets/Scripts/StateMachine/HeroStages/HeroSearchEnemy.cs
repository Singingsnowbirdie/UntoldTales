using UnityEngine;

/// <summary>
/// состояние при котором герой ищет себе цель для атаки
/// </summary>
public class HeroSearchEnemy : IStage
{
    private Hero Hero;

    public HeroSearchEnemy(Hero hero)
    {
        Hero = hero;
    }

    public void EnterStage()
    {
        SearchEnemy();
    }

    public void ExitStage()
    {
        // Debug.Log("HeroSearchEnemy выход");
    }

    public string StageName { get; set; }

    /// <summary>
    /// следующее состояние
    /// </summary>
    private void SetNextState()
    {
        if (Hero.CurrentTarget) Hero.HeroStateMachine.SetStage(Hero.HeroStateMachine.Stages[typeof(HeroMoveToEnemy)]);
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void SearchEnemy()
    {
       
        if (Hero.CurrentTarget) {SetNextState(); return;} else ExitStage();
        Debug.Log("ищу цель");
        Hero.CurrentTarget = GameObject.Find("target").GetComponent<PassiveAbilityHero>();
    }
}
