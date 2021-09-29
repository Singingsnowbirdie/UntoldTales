using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Initial : IMatchStage
{
    public void Enter()
    {
        EventManager.MatchInitialStageEnterEventInvoke();
        Debug.Log("Match Initial stage enter");
    }

    public void Exit()
    {
        EventManager.MatchInitialStageExitEventInvoke();
        Debug.Log("Match Initial stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
