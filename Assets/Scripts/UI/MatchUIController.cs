using UnityEngine;
using UnityEngine.UI;

// UI Матча

public class MatchUIController : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая стадия
    /// </summary>
    [SerializeField] Text currentStageText;

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
    }
}
