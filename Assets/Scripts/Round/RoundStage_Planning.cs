using UnityEngine;

public class RoundStage_Planning : IRoundStage
{
    public void Enter()
    {
        EventManager.RoundPlanningStageEnterEventInvoke();
        Debug.Log("Planning stage enter");

    }

    public void Exit()
    {
        EventManager.RoundPlanningStageExitEventInvoke();
        Debug.Log("Planning stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
