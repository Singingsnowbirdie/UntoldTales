using UnityEngine;

public class RoundStage_Battle : IRoundStage
{
    public void Enter()
    {
        EventManager.RoundBattleStageEnterEventInvoke();
        Debug.Log("Battle stage enter");
    }

    public void Exit()
    {
        EventManager.RoundBattleStageExitEventInvoke();
        Debug.Log("Battle stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
