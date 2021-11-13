using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    /// интерфейс раунда
    /// </summary>
    [SerializeField] GameObject roundPanel;

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
    }

    /// <summary>
    /// Показывает текущую стадию
    /// </summary>
    /// <param name="obj"></param>
    private void ShowCurrentStage(IStage stage)
    {
        currentStageText.text = stage.ToString();
        //при входе в стадию планирования
        if (stage is PlanningStage)
        {
            //выключаем защитную панель
            protectionPanel.SetActive(false);
            //показываем интерфейс раунда
            roundPanel.SetActive(true);
        }
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnStageEnter -= ShowCurrentStage;
        EventManager.OnHeroSelected -= EnableProtectionPanel;
    }
}
