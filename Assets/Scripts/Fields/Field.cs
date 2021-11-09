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

    void CreatePoints()
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
            CreatePoints();
        }
        return enemyPoints;
    }
}
