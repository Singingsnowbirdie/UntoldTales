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

    private void Update() 
    {
        if (active)
        {
            heroStateMachine.SetStage(heroStateMachine.Stages[typeof(HeroSearchEnemy)]);
        }
    }
}
