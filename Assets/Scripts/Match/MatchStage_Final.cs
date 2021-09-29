using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStage_Final : IMatchStage
{
    public void Enter()
    {
        EventManager.MatchFinalStageEnterEventInvoke();
        Debug.Log("Match Final stage enter");
    }

    public void Exit()
    {
        EventManager.MatchFinalStageExitEventInvoke();
        Debug.Log("Match Final stage exit");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
