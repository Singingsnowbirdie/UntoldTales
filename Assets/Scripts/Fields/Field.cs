using System.Collections.Generic;
using UnityEngine;

//игровое поле

public class Field : MonoBehaviour
{
    //точки резерва (своего)
    [SerializeField] //тест
    List<Point> reservePoints;

    //точки со своей половины поля
    [SerializeField] //тест
    List<Point> friendlyPoints;

    //все точки поля
    [SerializeField] //тест
    List<Point> fieldPoints;

    void Awake()
    {
        reservePoints = new List<Point>();
        friendlyPoints = new List<Point>();
        fieldPoints = new List<Point>();
    }

    void Start()
    {
        //находим все точки
        Point[] points = gameObject.GetComponentsInChildren<Point>();

        //получаем точки резерва (своего)
        foreach (var item in points)
        {
            if (item.type == PointType.ReservePoint)
            {
                reservePoints.Add(item);
            }
        }

        //получаем все точки со своей половины поля
        foreach (var item in points)
        {
            if (item.type == PointType.FriendlyPoint)
            {
                friendlyPoints.Add(item);
            }
        }

        //получаем все точки поля
        fieldPoints.AddRange(friendlyPoints);
        foreach (var item in points)
        {
            if (item.type == PointType.EmemyPoint || item.type == PointType.NeutralPoint)
            {
                fieldPoints.Add(item);
            }
        }

    }


}
