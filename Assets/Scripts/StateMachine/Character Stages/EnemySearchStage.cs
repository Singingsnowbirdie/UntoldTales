using UnityEngine;

//Состояние персонажа: поиск цели 
public class EnemySearchStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public EnemySearchStage(Character character)
    {
        this.character = character;
    }

    /// <summary>
    /// Персонаж
    /// </summary>
    private Character character;

    /// <summary>
    /// Определитель цели
    /// </summary>
    private TargetFinder findTarget;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public void EnterStage()
    {
        SearchEnemy();
    }

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public void ExitStage()
    {
    }

    /// <summary>
    /// Запускает следующее состояние
    /// </summary>
    private void SetNextStage()
    {
        if (character.CurrentTarget)
        {
            EnemyApproachingStage aa = character.StateMachine.Stages[typeof(EnemyApproachingStage)] as EnemyApproachingStage;
            aa.pathfinding.target = character.CurrentTarget.gameObject;
            character.StateMachine.SetStage(character.StateMachine.Stages[typeof(EnemyApproachingStage)]);
        } 
    }

    /// <summary>
    /// Поиск цели
    /// </summary>
    private void SearchEnemy()
    {
        if (character.CurrentTarget) {SetNextStage(); return;} else ExitStage();

        Debug.Log("ищу цель");
        
        findTarget = new TargetFinder();
        findTarget.FindNearestTarget(character);
    }
}
