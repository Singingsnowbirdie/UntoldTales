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
    /// "защитная" панель (не дает игроку кликать по объектам сцены)
    /// </summary>
    [SerializeField] GameObject protectionPanel;

    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //Подписки
        EventManager.OnStageEnter += ShowCurrentStage;
        EventManager.OnHeroSelected += EnableProtectionPanel;
    }

    /// <summary>
    /// Включает защитную панель после выбора персонажа на Круге Героев
    /// </summary>
    /// <param name="obj"></param>
    private void EnableProtectionPanel(string obj)
    {
        protectionPanel.SetActive(true);
        EventManager.OnHeroSelected -= EnableProtectionPanel;
    }

    /// <summary>
    /// Показывает текущую стадию
    /// </summary>
    /// <param name="obj"></param>
    private void ShowCurrentStage(IStage stage)
    {
        currentStageText.text = stage.ToString();
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
