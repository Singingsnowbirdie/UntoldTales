public class RoundBehaviourBattle : IRoundBehaviour
{
    public void Enter()
    {
        EventManager.RoundBattleStateEnterEventInvoke();
    }

    public void Exit()
    {
        EventManager.RoundBattleStateExitEventInvoke();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
