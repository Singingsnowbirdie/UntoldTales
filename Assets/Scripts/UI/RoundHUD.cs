﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundHUD : MonoBehaviour
{
    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //подписываемся на изменение чего-либо
        EventManager.OnSomethingChanged += SomethingChanged;
    }

    /// <summary>
    /// Количество чего-то поменялось
    /// </summary>
    private void SomethingChanged(int amount, Changeable value)
    {
        if (value == Changeable.Experience) leadershipCounter.text = $"Уровень лидерства: {amount}";
        else if (value == Changeable.Leadership) { experienceCounter.text = $"Очки опыта Хранителя: {amount}"; }
        else if (value == Changeable.Health) { keeperHealthCounter.text = $"Очков здоровья: {amount}"; }
        else if (value == Changeable.Reserve) { heroesInReserveCounter.text = $"Героев в резерве: {amount}"; }
        else if (value == Changeable.Storage) { heroesInTemporaryStorageCounter.text = $"Героев во временном хранилище: {amount}"; }
        else if (value == Changeable.Field) { heroesOnTheFieldCounter.text = $"Героев на поле: {amount}"; }
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnSomethingChanged -= SomethingChanged;
    }

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
}
