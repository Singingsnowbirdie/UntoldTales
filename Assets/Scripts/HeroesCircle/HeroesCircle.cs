using System.Collections.Generic;
using UnityEngine;

public class HeroesCircle : MonoBehaviour
{
    /// <summary>
    /// Точки, над которыми будут спавниться случайные герои
    /// </summary>
    Point[] points;

    /// <summary>
    /// Все заспавненные герои
    /// </summary>
    public List<Hero> Heroes { get; set; }

    private void Start()
    {
        //получаем все точки 
        points = gameObject.GetComponentsInChildren<Point>();
        //получаем всех героев 
        Heroes = CreateHeroes();
    }

    private List<Hero> CreateHeroes()
    {
        //создаем пустой список
        List<Hero> heroes = new List<Hero>();
        //получаем коллекцию карточек всех существующих героев
        List<HeroInfo> infos = GetAllHeroInfos();
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
            //добавляем его в список
            heroes.Add(heroGO.GetComponent<Hero>());

        }
        return heroes;
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
    /// Проверяет, всех ли героев разобрали
    /// </summary>
    internal bool AllHeroesSelected(Hero hero)
    {
        for (int i = 0; i < Heroes.Count; i++)
        {
            if (Heroes[i].ID == hero.ID)
            {
                Heroes.RemoveAt(i);
                break;
            }
        }
        if (Heroes.Count > 2)
        {
            return false;
        }
        return true;
    }
}

