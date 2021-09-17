using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI

public class RoundSceneUIManager : MonoBehaviour
{
    [SerializeField] Text roundStateText;
    [SerializeField] Button endRoundStateButton;

    private void Start()
    {
        EventManager.OnRoundPlanningStageEnter += ShowPlanningStateMess;
    }

    private void ShowPlanningStateMess()
    {
        roundStateText.text = "Фаза планирования";
    }


}
