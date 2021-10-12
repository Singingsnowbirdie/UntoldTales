//этот герой не умеет накапливать энергию, не имеет ульты, но имеет пассивную способность

using UnityEngine;

public class PassiveAbilityHero : Hero
{
    public bool active = true;

    private void Update() 
    {
        if (active)
        {
            Initialize();
            heroStateMachine.SetStage(heroStateMachine.Stages[typeof(HeroSearchEnemy)]);
        }
    }
}
