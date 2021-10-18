using System;
using UnityEngine;

public class Mob : MonoBehaviour
{

    /// <summary>
    /// Информация о мобе (карточка)
    /// </summary>
    public MobInfo info;

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    readonly int health;

    /// </summary>
    /// состояния
    /// </summary>
    StateMachine stateMachine;

    /// <summary>
    /// Текущая цель (герой)
    /// </summary>
    Hero currentTarget;

    /// <summary>
    /// Точка, на которой стоит моб (?)
    /// </summary>
    Point point;

    /// <summary>
    /// Инициализатор
    /// </summary>
    public virtual void Initialize(Point point)
    {
        stateMachine = new MobStateMachine(this);
        this.point = point;
    }

    /// <summary>
    /// Есть цель
    /// </summary>
    /// <returns></returns>
    internal bool HasTarget()
    {
        if (currentTarget != null)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Самоуничтожение
    /// </summary>
    internal void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
