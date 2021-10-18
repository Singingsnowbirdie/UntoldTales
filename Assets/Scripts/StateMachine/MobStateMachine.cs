//машина состояний для моба

public class MobStateMachine : StateMachine
{
    public MobStateMachine(Mob mob)
    {
        InitStates(mob);
    }
    void InitStates(Mob mob)
    {
        Stages.Add(typeof(EnemySearchStage), new EnemySearchStage(mob));
        Stages.Add(typeof(ConvergenceStage), new ConvergenceStage(mob));
        Stages.Add(typeof(AttackStage), new AttackStage(mob));
    }
}
