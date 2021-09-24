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
    /// Текст: количество очков здоровья
    /// </summary>
    [SerializeField] Text keeperHealthCounter;

    /// <summary>
    /// Текст: количество героев в отряде
    /// </summary>
    [SerializeField] Text heroesCounter;

    /// <summary>
    /// Кнопка "купить опыт"
    /// </summary>
    [SerializeField] Button buyExperienceButton;

    /// <summary>
    /// Кнопка "купить героя"
    /// </summary>
    [SerializeField] Button buyHeroButton;

    /// <summary>
    /// При активации
    /// </summary>
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
        //подписываемся на изменение количества очков здоровья
        EventManager.OnKeeperHealthChanged += ShowHealth;
        //подписываемся на изменение количества героев в отряде
        EventManager.OnSquadSizeChanged += ShowHeroesAmount;
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
        EventManager.OnLeadershipChanged -= ShowLeadership;
        EventManager.OnKeeperHealthChanged -= ShowHealth;
        EventManager.OnSquadSizeChanged -= ShowHeroesAmount;

    }

    #region ТЕКСТ
    /// <summary>
    /// Показывает новое значение очков здоровья
    /// </summary>
    private void ShowHealth(int amount) { keeperHealthCounter.text = $"Очков здоровья: {amount}"; }

    /// <summary>
    /// Показывает новое значение очков лидерства
    /// </summary>
    private void ShowLeadership(int amount) { leadershipCounter.text = $"Уровень лидерства: {amount}"; }

    /// <summary>
    /// Показывает количество героев в отряде
    /// </summary>
    /// <param name="obj"></param>
    private void ShowHeroesAmount(int amount) { heroesCounter.text = $"Героев в отряде: {amount}"; }
    #endregion

    #region КНОПКИ
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
    /// Кнопка "купить героя"
    /// </summary>
    public void BuyHero()
    {
        Hero hero = new HeroExample();
        EventManager.BuyHero(hero);
    }
    #endregion

    #region СМЕНА ФАЗЫ РАУНДА
    /// <summary>
    /// Входим в фазу планирования
    /// </summary>
    private void ShowPlanningStateMess()
    {
        roundStateText.text = "Фаза планирования";
        buyExperienceButton.enabled = true;
        buyHeroButton.enabled = true;
    }

    /// <summary>
    /// Входим в фазу боя
    /// </summary>
    private void ShowBattleStateMess()
    {
        roundStateText.text = "Фаза боя";
    }

    /// <summary>
    /// Входим в фазу расчетов
    /// </summary>
    private void ShowCalculationStateMess()
    {
        roundStateText.text = "Фаза расчетов";
        buyExperienceButton.enabled = false;
    }

    /// <summary>
    /// Входим в фазу подбора соперника
    /// </summary>
    private void ShowOpponentSelectionStateMess()
    {
        roundStateText.text = "Фаза подбора соперников";
    }
    #endregion
}
