using UnityEngine;

public class RoundBehaviourOpponentSelection : IRoundBehaviour
{
    public void Enter()
    {
        EventManager.RoundOpponentSelectionStageEnterEventInvoke();
        Debug.Log("Opponent Selection stage enter");
    }

    public void Exit()
    {
        EventManager.RoundOpponentSelectionStageExitEventInvoke();
        Debug.Log("Opponent Selection stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
