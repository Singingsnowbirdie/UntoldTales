//этот герой не умеет накапливать энергию, не имеет ульты, но имеет пассивную способность

using UnityEngine;

public class PassiveAbilityHero : Hero
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="info"></param>
    public PassiveAbilityHero(HeroInfo info) : base(info) { }

    public bool active = true;
    private void Start() 
    {
        
    }

    private void Update() 
    {
        if (active)
        {
            HeroSearchEnemy heroSearchEnemy = heroStateMachine.Stages[typeof(HeroSearchEnemy)] as HeroSearchEnemy;
            heroSearchEnemy.Hero = this;
            heroStateMachine.SetStage(heroStateMachine.Stages[typeof(HeroSearchEnemy)]);
        }
    }
}
