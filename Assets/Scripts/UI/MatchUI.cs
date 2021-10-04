using System;
using UnityEngine;
using UnityEngine.UI;

// UI Матча

public class MatchUI : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая стадия
    /// </summary>
    [SerializeField] Text currentStageText;

    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //Подписка на смену стадии
        EventManager.OnStageEnter += ShowCurrentStage;
    }

    /// <summary>
    /// Показывает текущую стадию
    /// </summary>
    /// <param name="obj"></param>
    private void ShowCurrentStage(string stage)
    {
        currentStageText.text = stage;
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnStageEnter -= ShowCurrentStage;
    }
}
