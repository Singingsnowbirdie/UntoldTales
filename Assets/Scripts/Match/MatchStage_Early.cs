using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Early : IMatchStage
{
    public void Enter()
    {
        EventManager.MatchEarlyStageEnterEventInvoke();
        Debug.Log("Match Early stage enter");
    }

    public void Exit()
    {
        EventManager.MatchEarlyStageExitEventInvoke();
        Debug.Log("Match Early stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
