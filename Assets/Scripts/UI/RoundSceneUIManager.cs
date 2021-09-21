using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI
// В текущей реализации есть баг: OnEnable() вызывается позже инициализации раунда,
// и первый вызов события OnRoundPlanningStageEnter не отлавливается
// Решение: инициализировать UI менеджер раньше

public class RoundSceneUIManager : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая фаза раунда
    /// </summary>
    [SerializeField] Text roundStateText;

    /// <summary>
    /// Текст: количество очков лидерства
    /// </summary>
    [SerializeField] Text leadershipCounter;

    /// <summary>
    /// Кнопка "купить опыт"
    /// </summary>
    [SerializeField] Button buyingExperienceButton;

    private void OnEnable()
    {
        //подписываемся на вхождение в фазу планирования
        EventManager.OnRoundPlanningStageEnter += ShowPlanningStateMess;
        //подписываемся на вхождение в фазу боя
        EventManager.OnRoundBattleStageEnter += ShowBattleStateMess;
        //подписываемся на вхождение в фазу расчетов
        EventManager.OnRoundCalculationStageEnter += ShowCalculationStateMess;
        //подписываемся на вхождение в фазу подбора соперника
        EventManager.OnRoundOpponentSelectionStageEnter += ShowOpponentSelectionStateMess;
        //подписываемся на изменение количества очков лидерства
        EventManager.OnLeadershipChanged += ShowLeadership;
    }

    /// <summary>
    /// Показывает новое значение очков лидерства
    /// </summary>
    private void ShowLeadership(int amount)
    {
        leadershipCounter.text = $"Уровень лидерства: {amount}";
    }

    /// <summary>
    /// Входим в стадию планирования
    /// </summary>
    private void ShowPlanningStateMess()
    {
        roundStateText.text = "Фаза планирования";
        buyingExperienceButton.enabled = true;
    }
    
    /// <summary>
    /// Входим в стадию боя
    /// </summary>
    private void ShowBattleStateMess()
    {
        roundStateText.text = "Фаза боя";
    }

    /// <summary>
    /// Входим в стадию расчетов
    /// </summary>
    private void ShowCalculationStateMess()
    {
        roundStateText.text = "Фаза расчетов";
        buyingExperienceButton.enabled = false;
    }

    /// <summary>
    /// Входим в стадию подбора соперника
    /// </summary>
    private void ShowOpponentSelectionStateMess()
    {
        roundStateText.text = "Фаза подбора соперников";
    }

    /// <summary>
    /// Кнопка "сменить фазу раунда"
    /// </summary>
    public void ChangeRoundStage()
    {
        EventManager.ChangeRoundStage();
    }

    /// <summary>
    /// Кнопка "купить очки лидерства"
    /// </summary>
    public void BuyLeadership()
    {
        EventManager.BuyLeadership();
    }    

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnRoundPlanningStageEnter -= ShowPlanningStateMess;
        EventManager.OnRoundBattleStageEnter -= ShowBattleStateMess;
        EventManager.OnRoundCalculationStageEnter -= ShowCalculationStateMess;
        EventManager.OnRoundOpponentSelectionStageEnter -= ShowOpponentSelectionStateMess;
    }
}
