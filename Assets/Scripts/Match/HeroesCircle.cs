using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroesCircle : MonoBehaviour
{
    private void OnEnable()
    {
        heroes = new Heroes(GetPoints());
    }

    /// <summary>
    /// Герои Круга
    /// </summary>
    Heroes heroes;

    /// <summary>
    /// Круг на время
    /// </summary>
    public bool isOnTime { get; set; }

    /// <summary>
    /// Возвращает все точки спавна
    /// </summary>
    /// <returns></returns>
    private Point[] GetPoints()
    {
        return gameObject.GetComponentsInChildren<Point>();
    }

    /// <summary>
    /// Возвращает имя случайного героя
    /// </summary>
    /// <returns></returns>
    internal string GetRandomHeroName()
    {
        return heroes.GetRandomHeroName();
    }

    /// <summary>
    /// Проверяет, все ли герои розданы
    /// </summary>
    /// <returns></returns>
    internal bool AllHeroesDistributed()
    {
        return heroes.AllHeroesDistributed();
    }

    /// <summary>
    /// Удаляет героев
    /// </summary>
    internal void DestroyHeroes()
    {
        heroes.DestroyHeroes();
    }
}

