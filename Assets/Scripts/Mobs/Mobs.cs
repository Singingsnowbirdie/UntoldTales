using System.Collections.Generic;
using UnityEngine;

class Mobs
{
    public Mobs(int pveRoundsCounter, List<Point> points)
    {
        InitMobsDB();
        mobs = CreateMobs(points);
        this.pveRoundsCounter = pveRoundsCounter;
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
    List<Mob> mobs;

    /// <summary>
    /// Счетчик сыгранных ПвЕ раундов
    /// </summary>
    private readonly int pveRoundsCounter;

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
            if ((item as GameObject).GetComponent<Mob>().info.СombatType == CombatType.Melee)
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
    private List<Mob> CreateMobs(List<Point> enemyPoints)
    {
        //список мобов
        List<Mob> list = new List<Mob>();

        //временный список точек, на которых могут быть размещены мобы
        List<Point> freePoints = new List<Point>();
        freePoints.AddRange(enemyPoints);

        //расставляем мобов
        foreach (var item in SelectMobs())
        {
            //выбираем точку на поле
            Point point = freePoints[Random.Range(0, freePoints.Count - 1)];
            //спавним моба на точку
            list.Add(UtilsManager.Spawn(item, point.transform.position).GetComponent<Mob>());
            //сообщаем точке, что на ней стоит моб
            point.ChildrenCharacter = item;
            //сообщаем мобу, на какой точке он стоит (?)
            item.GetComponent<Mob>().Initialize(point);
            //удаляем точку из списка (чтоб не заспавнить на нее еще кого-то)
            freePoints.Remove(point);
        }

        return list;
    }

    /// <summary>
    /// Выбираем мобов, которых будем спавнить
    /// </summary>
    private List<GameObject> SelectMobs()
    {
        //создаем новый список мобов
        List<GameObject> temp = new List<GameObject>();

        //добавляем трех ближников
        temp.Add(meleeMobsPrefabs[Random.Range(0, meleeMobsPrefabs.Count)]);

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


