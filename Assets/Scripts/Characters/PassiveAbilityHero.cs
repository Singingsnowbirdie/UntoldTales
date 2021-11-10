//пример героя
//этот герой не умеет накапливать энергию, не имеет ульты, но имеет пассивную способность

public class PassiveAbilityHero : Hero
{
    public bool isActive = false;

    private void Update()
    {
        if (isActive)
        {
            stateMachine.SetStage(stateMachine.Stages[typeof(EnemySearchStage)]);
        }
    }
}
