//машина состояний для моба

public class MobStateMashine : StateMachine
{
    public MobStateMashine(Mob mob)
    {
        Initialize();
        InitStates(mob);
    }
    void InitStates(Mob mob)
    {
        Stages.Add(typeof(EnemySearchStage), new EnemySearchStage(mob));
        Stages.Add(typeof(ConvergenceStage), new ConvergenceStage(mob));
        Stages.Add(typeof(AttackStage), new AttackStage(mob));
    }
}
