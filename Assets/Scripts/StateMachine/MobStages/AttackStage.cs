using UnityEngine;

public class AttackStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public AttackStage(Mob mob)
    {
        this.mob = mob;
    }

    /// <summary>
    /// Этот моб
    /// </summary>
    private Mob mob;

    /// <summary>
    /// Название состояния
    /// </summary>
    public string StageName { get; set; }

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public void Enter()
    {
        Attack();
    }

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public void Exit() { }

    /// <summary>
    /// Атака
    /// </summary>
    private void Attack()
    {
        Debug.Log("Mob attack");
    }
}

