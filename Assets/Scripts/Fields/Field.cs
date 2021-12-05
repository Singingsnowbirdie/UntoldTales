using System;
using System.Collections.Generic;
using UnityEngine;

//игровое поле

public class Field : MonoBehaviour
{
    //точки резерва (своего)
    List<Point> reservePoints;

    //точки со своей половины поля
    List<Point> friendlyPoints;

    //точки с вражеской половины поля (для PvE раунда)
    List<Point> enemyPoints;

    //все точки поля
    List<Point> fieldPoints;

    /// <summary>
    /// Спавнит героя и помещает на свободную ячейку в резерве
    /// </summary>
    private void SpawnHero(Hero hero)
    {
        //префаб героя
        GameObject pref = hero.Info.Prefab;
        //свободная точка в резерве
        Point point = FindFreePointInReserve();

        if (point != null) //на всякий случай
        {
            //создаем героя на пустой точке резерва
            GameObject heroGO = Instantiate(pref, point.transform);
            //помещаем на него скрипт

        }
    }

    /// <summary>
    /// Определяет все точки
    /// </summary>
    void GetPoints()
    {
        reservePoints = new List<Point>();
        friendlyPoints = new List<Point>();
        fieldPoints = new List<Point>();
        enemyPoints = new List<Point>();

        //находим все точки
        Point[] points = gameObject.GetComponentsInChildren<Point>();

        //получаем точки резерва (своего)
        foreach (var item in points)
        {
            if (item.Type == PointType.ReservePoint)
            {
                reservePoints.Add(item);
            }
        }

        //получаем все точки со своей половины поля
        foreach (var item in points)
        {
            if (item.Type == PointType.FriendlyPoint)
            {
                friendlyPoints.Add(item);
            }
        }

        //получаем все точки с вражеской половины поля
        foreach (var item in points)
        {
            if (item.Type == PointType.EnemyPoint)
            {
                enemyPoints.Add(item);
            }
        }

        //получаем все точки поля
        fieldPoints.AddRange(friendlyPoints);
        fieldPoints.AddRange(enemyPoints);
        foreach (var item in points)
        {
            if (item.Type == PointType.NeutralPoint)
            {
                fieldPoints.Add(item);
            }
        }

    }

    /// <summary>
    /// Возвращает вражеские точки
    /// </summary>
    /// <returns></returns>
    public List<Point> GetEnemyPoints()
    {
        if (enemyPoints == null)
        {
            GetPoints();
        }
        return enemyPoints;
    }

    /// <summary>
    /// Возвращает точки резерва
    /// </summary>
    /// <returns></returns>
    public List<Point> GetReservePoints()
    {
        if (enemyPoints == null)
        {
            GetPoints();
        }
        return reservePoints;
    }

    /// <summary>
    /// Находит свободную ячейку в резерве
    /// </summary>
    /// <returns></returns>
    public Point FindFreePointInReserve()
    {
        foreach (var item in GetReservePoints())
        {
            //если на этой точке никто не стоит
            if (item.GetComponentInChildren<Character>() == null)
            {
                return item;
            }
        }

        return null;
    }
}
