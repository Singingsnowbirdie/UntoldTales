using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI (раунд)

public class RoundUIManager : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая фаза раунда
    /// </summary>
    [SerializeField] Text roundStateText;

    /// <summary>
    /// Текст: очки опыта Хранителя
    /// </summary>
    [SerializeField] Text experienceCounter;

    /// <summary>
    /// Текст: количество очков лидерства
    /// </summary>
    [SerializeField] Text leadershipCounter;

    /// <summary>
    /// Текст: количество очков здоровья
    /// </summary>
    [SerializeField] Text keeperHealthCounter;

    /// <summary>
    /// Текст: количество героев в резерве
    /// </summary>
    [SerializeField] Text heroesInReserveCounter;

    /// <summary>
    /// Текст: количество героев во временном хранилище
    /// </summary>
    [SerializeField] Text heroesInTemporaryStorageCounter;

    /// <summary>
    /// Текст: количество героев на поле
    /// </summary>
    [SerializeField] Text heroesOnTheFieldCounter;

    /// <summary>
    /// Текст: количество монет
    /// </summary>
    [SerializeField] Text coinsCounter;

    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //подписываемся на изменение количества очков лидерства
        EventManager.OnExperienceChanged += ShowExperience;
        //подписываемся на изменение количества очков здоровья
        EventManager.OnKeeperHealthChanged += ShowHealth;
        //подписываемся на изменение количества героев в резерве
        EventManager.OnReserveSizeChanged += ShowReservedHeroesAmount;
        //подписываемся на изменение количества героев во временном хранилище
        EventManager.OnTemporaryStorageSizeChanged += ShowTemporaryStoredHeroesAmount;
        //подписываемся на изменение количества героев на поле
        EventManager.OnHeroesOnTheFieldAmountChanged += ShowHeroesOnTheFieldAmount;
        //подписываемся на изменение количества монет
        EventManager.OnCoinsAmountChanged += ShowCoinsAmount;
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnExperienceChanged -= ShowExperience;
        EventManager.OnKeeperHealthChanged -= ShowHealth;
        EventManager.OnReserveSizeChanged -= ShowReservedHeroesAmount;
        EventManager.OnTemporaryStorageSizeChanged -= ShowTemporaryStoredHeroesAmount;
        EventManager.OnHeroesOnTheFieldAmountChanged -= ShowHeroesOnTheFieldAmount;
    }

    #region ТЕКСТ
    /// <summary>
    /// Показывает новое значение очков здоровья
    /// </summary>
    private void ShowHealth(int amount) { keeperHealthCounter.text = $"Очков здоровья: {amount}"; }

    /// <summary>
    /// Показывает новое значение очков лидерства и опыта
    /// </summary>
    private void ShowExperience(int experience, int leadership) 
    { 
        experienceCounter.text = $"Очки опыта Хранителя: {experience}"; 
        leadershipCounter.text = $"Уровень лидерства: {leadership}"; 
    }

    /// <summary>
    /// Показывает количество героев в резерве
    /// </summary>
    /// <param name="obj"></param>
    private void ShowReservedHeroesAmount(int amount) { heroesInReserveCounter.text = $"Героев в резерве: {amount}"; }
    /// <summary>
    /// Показывает количество героев во временном хранилище
    /// </summary>
    /// <param name="amount"></param>
    private void ShowTemporaryStoredHeroesAmount(int amount) { heroesInTemporaryStorageCounter.text = $"Героев во временном хранилище: {amount}"; }
    /// <summary>
    /// Показывает количество героев на поле
    /// </summary>
    /// <param name="amount"></param>
    private void ShowHeroesOnTheFieldAmount(int amount) { heroesOnTheFieldCounter.text = $"Героев на поле: {amount}"; }
    /// <summary>
    /// Показывает количество монет у игрока
    /// </summary>
    /// <param name="obj"></param>
    private void ShowCoinsAmount(int amount) { coinsCounter.text = $"Монет: {amount}"; }
    #endregion

    #region КНОПКИ
    /// <summary>
    /// Кнопка "сменить фазу раунда"
    /// </summary>
    public void ChangeRoundStage()
    {
        EventManager.ChangeRoundStageBttnPressed();
    }

    /// <summary>
    /// Кнопка "купить опыт Хранителя"
    /// </summary>
    public void BuyExperience()
    {
        EventManager.BuyExperienceBttnPressed();
    }

    /// <summary>
    /// Кнопка "купить героя"
    /// </summary>
    public void BuyHero()
    {
        Hero hero = new UltimateHeroExample();
        EventManager.BuyHero(hero);
    }
    #endregion

}
