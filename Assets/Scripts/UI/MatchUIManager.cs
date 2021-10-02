using System;
using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI (матч)

public class MatchUIManager : MonoBehaviour
{
    /// <summary>
    /// Текст: стадия матча
    /// </summary>
    [SerializeField] Text matchStageText;
    /// <summary>
    /// Текст: этап стадии
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
        matchStageText.text = stage;
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnStageEnter -= ShowCurrentStage;
    }

    #region КНОПКИ
    /// <summary>
    /// Кнопка "сменить стадию матча"
    /// </summary>
    public void ChangeMatchStage()
    {
        EventManager.ChangeMatchStageBttnPressed();
    }
    #endregion
}
