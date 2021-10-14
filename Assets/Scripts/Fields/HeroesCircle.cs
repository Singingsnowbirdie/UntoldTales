using System.Collections.Generic;
using UnityEngine;

public class HeroesCircle : MonoBehaviour
{
    /// <summary>
    /// Создает героев и помещает их на точках спавна
    /// </summary>
    void CreateHeroes(Point[] points, List<HeroInfo> infos)
    {
        //создаем случайных героев (столько, сколько есть точек в круге)
        for (int i = 0; i < points.Length; i++)
        {
            //берем случайную карточку
            HeroInfo randInfo = infos[Random.Range(0, infos.Count)];
            //создаем го героя (берем префаб из карточки)
            GameObject heroGO = randInfo.Pref;
            //назначаем ему ID
            heroGO.GetComponent<Hero>().ID = i;
            //вешаем на него карточку
            heroGO.GetComponent<Hero>().info = randInfo;
            //помещаем его на точку
            Instantiate(heroGO, points[i].transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Возвращает коллекцию карточек всех героев 1 ранга
    /// </summary>
    private List<HeroInfo> GetAllHeroInfos()
    {
        //создаем пустой список
        List<HeroInfo> infos = new List<HeroInfo>();
        //помещаем в него всех героев 1 ранга
        foreach (var item in Resources.LoadAll<HeroInfo>("HeroesInfo"))
        {
            if (item.Rank == 1)
            {
                infos.Add(item);
            }
        }
        return infos;
    }

    /// <summary>
    /// Возвращает все точки спавна
    /// </summary>
    /// <returns></returns>
    private Point[] GetPoints()
    {
        return gameObject.GetComponentsInChildren<Point>();
    }

    /// <summary>
    /// Возвращает список героев
    /// </summary>
    /// <returns></returns>
    internal void CreateHeroes()
    {
        //получаем все точки спавна
        Point[] points = GetPoints();
        //получаем коллекцию карточек всех существующих героев
        List<HeroInfo> infos = GetAllHeroInfos();
        //создаем героев
        CreateHeroes(points, infos);
    }
}

