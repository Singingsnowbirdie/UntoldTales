//стейт-машина персонажа

public class CharacterStateMachine : StateMachine
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public CharacterStateMachine(Character character)
    {
        //добавляем состояния
        Stages.Add(typeof(ReserveStage), new ReserveStage());
        Stages.Add(typeof(IdleStage), new IdleStage());
        Stages.Add(typeof(EnemySearchStage), new EnemySearchStage(character));
        Stages.Add(typeof(EnemyApproachingStage), new EnemyApproachingStage(character));
        Stages.Add(typeof(AttackStage), new AttackStage(character));
    }
}
