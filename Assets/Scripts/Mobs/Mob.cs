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
    int health;

    /// </summary>
    /// состояния
    /// </summary>
    public StateMachine stateMachine;

    /// <summary>
    /// Текущая цель (герой)
    /// </summary>
    [HideInInspector]
    public Hero CurrentTarget;

    /// <summary>
    /// Инициализатор
    /// </summary>
    public virtual void Initialize()
    {
        stateMachine = new MobStateMashine(this);
    }

    /// <summary>
    /// Смена состояний 
    /// </summary>
    internal static void ChangeStage()
    {

    }

    /// <summary>
    /// Самоуничтожение
    /// </summary>
    internal void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
