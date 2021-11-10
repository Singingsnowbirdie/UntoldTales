using UnityEngine;

//Состояние персонажа: атака

public class AttackStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public AttackStage(Character character)
    {
        this.character = character;
    }

    /// <summary>
    /// Персонаж
    /// </summary>
    private Character character;

    /// <summary>
    /// Отсчет времени
    /// </summary>
    private float attackCooldown = 0f;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public void EnterStage()
    {
        Attack();
    }

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public void ExitStage()
    {
    }

    /// <summary>
    /// Атака
    /// </summary>
    private void Attack()
    {
        //счетчик до следующей атаки
        attackCooldown -= Time.deltaTime;

        if(attackCooldown <= 0)
        {
            Debug.Log("атакую цель");
            // HitTarget();

            character.Anim.SetTrigger("Attack");
            attackCooldown = 1f/ character.Model.AttackSpeed;
        }
    }

    /// <summary>
    /// Единичная атака
    /// </summary>
    public void HitTarget()
    {
        character.CurrentTarget.Model.Health--;
        Debug.Log("HitTarget");
    }
}
