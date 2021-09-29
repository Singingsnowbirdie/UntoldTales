using UnityEngine;
using UnityEngine.UI;

// Временный менеджер UI (матч)

public class MatchUIManager : MonoBehaviour
{
    /// <summary>
    /// Текст: текущая стадия матча
    /// </summary>
    [SerializeField] Text matchStageText;

    /// <summary>
    /// При активации
    /// </summary>
    private void OnEnable()
    {
        //подписываемся на вхождение в начальную стадию
        EventManager.OnMatchInitialStageEnter += ShowInitialStageMess;
        //подписываемся на вхождение в раннюю стадию
        EventManager.OnMatchEarlyStageEnter += ShowEarlyStageMess;
        //подписываемся на вхождение в позднюю стадию
        EventManager.OnMatchLateStageEnter += ShowLateStageMess;
        //подписываемся на вхождение в финальную стадию
        EventManager.OnMatchFinalStageEnter += ShowFinalStageMess;
    }

    /// <summary>
    /// ПОказать сообщение "финальная стадия"
    /// </summary>
    private void ShowFinalStageMess()
    {
        matchStageText.text = "Финальная стадия матча";
    }

    /// <summary>
    /// Показать сообщение "поздняя стадия"
    /// </summary>
    private void ShowLateStageMess()
    {
        matchStageText.text = "Поздняя стадия матча";
    }

    /// <summary>
    /// Показать сообщение "ранняя стадия"
    /// </summary>
    private void ShowEarlyStageMess()
    {
        matchStageText.text = "Ранняя стадия матча";
    }

    /// <summary>
    /// Показать сообщение "начальная стадия"
    /// </summary>
    private void ShowInitialStageMess()
    {
        matchStageText.text = "Начальная стадия матча";
    }

    /// <summary>
    /// При уничтожении монобеха
    /// </summary>
    private void OnDestroy()
    {
        //отписываемся от всего
        EventManager.OnMatchInitialStageEnter -= ShowInitialStageMess;
        EventManager.OnMatchEarlyStageEnter -= ShowEarlyStageMess;
        EventManager.OnMatchLateStageEnter -= ShowLateStageMess;
        EventManager.OnMatchFinalStageEnter -= ShowFinalStageMess;
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

    #region СМЕНА СТАДИИ МАТЧА

    #endregion
}
