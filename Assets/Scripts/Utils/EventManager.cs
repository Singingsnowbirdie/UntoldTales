using System;

//менеджер событий (временная реализация?)

public static class EventManager
{
    #region СОБЫТИЯ РАУНДА (фазы)
    //Вход в фазу планирования
    public static event Action OnRoundPlanningStageEnter;
    //Выход из фазы планирования
    public static event Action OnRoundPlanningStageExit;
    //Вход в фазу боя
    public static event Action OnRoundBattleStageEnter;
    //Выход из фазы боя
    public static event Action OnRoundBattleStageExit;
    //Вход в фазу расчетов
    public static event Action OnRoundCalculationStageEnter;
    //Выход из фазы расчетов
    public static event Action OnRoundCalculationStageExit;
    //Вход в фазу подбора соперников
    public static event Action OnRoundOpponentSelectionStageEnter;
    //Выход из фазы подбора соперников
    public static event Action OnRoundOpponentSelectionStageExit;
    #endregion

    #region МЕТОДЫ ВЫЗОВА СОБЫТИЙ
    /// <summary>
    /// Вход в фазу планирования
    /// </summary>
    public static void RoundPlanningStageEnterEventInvoke() { OnRoundPlanningStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы планирования
    /// </summary>
    public static void RoundPlanningStageExitEventInvoke() { OnRoundPlanningStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу боя
    /// </summary>
    public static void RoundBattleStageEnterEventInvoke() { OnRoundBattleStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы боя
    /// </summary>
    public static void RoundBattleStageExitEventInvoke() { OnRoundBattleStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу расчетов
    /// </summary>
    public static void RoundCalculationStageEnterEventInvoke() { OnRoundCalculationStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы расчетов
    /// </summary>
    public static void RoundCalculationStageExitEventInvoke() { OnRoundCalculationStageExit?.Invoke(); }
    /// <summary>
    /// Вход в фазу подбора соперников
    /// </summary>
    public static void RoundOpponentSelectionStageEnterEventInvoke() { OnRoundOpponentSelectionStageEnter?.Invoke(); }
    /// <summary>
    /// Выход из фазы подбора соперников
    /// </summary>
    public static void RoundOpponentSelectionStageExitEventInvoke() { OnRoundOpponentSelectionStageExit?.Invoke(); }
    #endregion
}
