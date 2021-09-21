using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    /// <summary>
    /// Текущая цель
    /// </summary>
    Hero currentTarget;

    /// <summary>
    /// Выбор цели
    /// </summary>
    public void SelectTarget()
    {

    }

    /// <summary>
    /// Двигает персонажа
    /// </summary>
    public void Move()
    {
        
    }

    /// <summary>
    /// Атака
    /// </summary>
    public void Attack()
    {

    }

    /// <summary>
    /// Жизненный цикл героя (после активации = после помещения на поле боя)
    /// </summary>
    /// <returns></returns>
    public IEnumerator HeroLifeCycleRoutine()
    {
        yield return null;
    }
}
