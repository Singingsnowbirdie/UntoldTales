using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI

public class RoundSceneUIManager : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая фаза раунда
    /// </summary>
    [SerializeField] Text roundStateText;

    /// <summary>
    /// Кнопка "завершить фазу"
    /// </summary>
    [SerializeField] Button endRoundStateButton;

    /// <summary>
    /// Кнопка "купить опыт"
    /// </summary>
    [SerializeField] Button buyingExperienceButton;

    private void Start()
    {
        //подписываемся на вхождение в фазу планирования
        EventManager.OnRoundPlanningStageEnter += ShowPlanningStateMess;
    }

    /// <summary>
    /// Входим в стадию планирования
    /// </summary>
    private void ShowPlanningStateMess()
    {
        roundStateText.text = "Фаза планирования";
        buyingExperienceButton.enabled = true;
    }


}
