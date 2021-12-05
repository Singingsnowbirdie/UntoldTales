using System.Collections.Generic;
using UnityEngine;

class Mobs
{
    public Mobs(int pveRoundsCounter, List<Point> points)
    {
        InitMobsDB();
        mobs = CreateMobs(points, pveRoundsCounter);
    }

    /// <summary>
    /// Все мобы с ближней атакой
    /// </summary>
    static List<GameObject> meleeMobsPrefabs;

    /// <summary>
    /// Все мобы с дальней атакой
    /// </summary>
    static List<GameObject> rangeMobsPrefabs;

    /// <summary>
    /// Список мобов, управлямых этим скриптом 
    /// </summary>
    List<Character> mobs;

    /// <summary>
    /// Подгружает базу мобов
    /// </summary>
    private void InitMobsDB()
    {
        //БД мобов
        var mobsDB = Resources.LoadAll("TestObjects/Mobs");

        meleeMobsPrefabs = new List<GameObject>();
        rangeMobsPrefabs = new List<GameObject>();

        //заполняем списки
        foreach (var item in mobsDB)
        {
            if ((item as GameObject).GetComponent<Character>().Info.СombatType == CombatType.Melee)
            {
                meleeMobsPrefabs.Add((item as GameObject));
            }
            else
            {
                rangeMobsPrefabs.Add((item as GameObject));
            }
        }
    }

    /// <summary>
    /// Спавним мобов
    /// </summary>
    private List<Character> CreateMobs(List<Point> enemyPoints, int pveRoundsCounter)
    {
        //список точек, на которых могут быть размещены мобы
        List<Point> freePoints = new List<Point>();
        freePoints.AddRange(enemyPoints);

        //список мобов
        List<Character> list = new List<Character>();

        //расставляем мобов
        foreach (var item in SelectMobs(pveRoundsCounter))
        {
            //выбираем точку на поле
            Point point = freePoints[Random.Range(0, freePoints.Count - 1)];
            //спавним моба на точку
            GameObject mobGO = Object.Instantiate(item, point.transform);
            list.Add(mobGO.GetComponent<Character>());
            //удаляем точку из списка (чтоб не заспавнить на нее еще кого-то)
            freePoints.Remove(point);
        }

        return list;
    }

    /// <summary>
    /// Выбираем мобов, которых будем спавнить
    /// </summary>
    private List<GameObject> SelectMobs(int pveRoundsCounter)
    {
        //создаем новый список мобов
        List<GameObject> temp = new List<GameObject>();

        //добавляем трех ближников
        for (int i = 0; i < 3; i++)
        {
            temp.Add(meleeMobsPrefabs[Random.Range(0, meleeMobsPrefabs.Count)]);
        }

        //если это второй из трех ПвЕ раундов
        if (pveRoundsCounter == 2)
        {
            //добавляем двух дальников
            for (int i = 0; i < 2; i++)
            {
                temp.Add(rangeMobsPrefabs[Random.Range(0, rangeMobsPrefabs.Count)]);
            }
        }
        //если это третий раунд
        else if (pveRoundsCounter == 3)
        {
            //добавляем четырех дальников
            for (int i = 0; i < 4; i++)
            {
                temp.Add(rangeMobsPrefabs[Random.Range(0, rangeMobsPrefabs.Count)]);
            }
        }

        return temp;
    }
}


