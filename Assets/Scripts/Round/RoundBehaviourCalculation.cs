public class RoundBehaviourCalculation : IRoundBehaviour
{
    public void Enter()
    {
        EventManager.RoundCalculationStateEnterEventInvoke();
    }

    public void Exit()
    {
        EventManager.RoundCalculationStateExitEventInvoke();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
