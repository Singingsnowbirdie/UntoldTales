using UnityEngine;

public class RoundStage_Calculation : IRoundStage
{
    public void Enter()
    {
        EventManager.RoundCalculationStageEnterEventInvoke();
        Debug.Log("Calculation stage enter");
    }

    public void Exit()
    {
        EventManager.RoundCalculationStageExitEventInvoke();
        Debug.Log("Calculation stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
