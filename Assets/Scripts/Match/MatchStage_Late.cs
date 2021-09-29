using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Late : IMatchStage
{
    public void Enter()
    {
        EventManager.MatchLateStageEnterEventInvoke();
        Debug.Log("Match Late stage enter");
    }

    public void Exit()
    {
        EventManager.MatchLateStageExitEventInvoke();
        Debug.Log("Match Late stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
