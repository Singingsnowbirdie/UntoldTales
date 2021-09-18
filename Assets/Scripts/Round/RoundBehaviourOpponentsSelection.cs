public class RoundBehaviourOpponentsSelection : IRoundBehaviour
{
    public void Enter()
    {
        EventManager.RoundOpponentsSelectionStateEnterEventInvoke();
    }

    public void Exit()
    {
        EventManager.RoundOpponentsSelectionStateExitEventInvoke();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
