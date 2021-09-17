using System;

//менеджер событий (временная реализация?)

public static class EventManager
{
    #region СОБЫТИЯ РАУНДА
    //Вход в фазу планирования
    public static event Action OnRoundPlanningStageEnter;
    //Вход в фазу планирования
    public static event Action OnRoundBattleStageEnter;
    //Вход в фазу расчетов
    public static event Action OnRoundCalculationStageEnter;
    //Вход в фазу подбора соперников
    public static event Action OnRoundOpponentsSelectionStageEnter;
    #endregion

    #region МЕТОДЫ ВЫЗОВА СОБЫТИЙ
    /// <summary>
    /// Вход в фазу планирования
    /// </summary>
    public static void RoundPlanningStateEnterEventInvoke() { OnRoundPlanningStageEnter?.Invoke(); }
    /// <summary>
    /// Вход в фазу боя
    /// </summary>
    public static void RoundBattleStateEnterEventInvoke() { OnRoundBattleStageEnter?.Invoke(); }
    /// <summary>
    /// Вход в фазу расчетов
    /// </summary>
    public static void RoundCalculationStateEnterEventInvoke() { OnRoundCalculationStageEnter?.Invoke(); }
    /// <summary>
    /// Вход в фазу подбора соперников
    /// </summary>
    public static void RoundOpponentsSelectionStateEnterEventInvoke() { OnRoundOpponentsSelectionStageEnter?.Invoke(); }
    #endregion
}
