public class RoundBehaviourPlanning : IRoundBehaviour
{
    public void Enter()
    {
        EventManager.RoundPlanningStateEnterEventInvoke();
    }

    public void Exit()
    {
        EventManager.RoundPlanningStateExitEventInvoke();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
