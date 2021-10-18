using System.Collections.Generic;
using UnityEngine;

internal class Heroes
{
    public Heroes(Point[] points)
    {
        heroes = CreateRandomHeroes(points);

        //подписываемся на выбор героя
        EventManager.OnHeroSelected += OnHeroSelected;
    }

    /// <summary>
    /// Игрок выбрал себе героя
    /// </summary>
    /// <param name="obj"></param>
    private void OnHeroSelected(string obj)
    {
        //отписываемся
        EventManager.OnHeroSelected -= OnHeroSelected;

        for (int i = 0; i < heroes.Count; i++)
        {
            //если герой не найден (удален) убираем из списка
            if (heroes[i] == null)
            {
                heroes.RemoveAt(i);
            }
            //если герой найден, отключаем возможность выбора
            else
            {
                heroes[i].gameObject.GetComponent<HeroCircleSelector>().IsAvailableForPlayer = false;
            }
        }
    }

    /// <summary>
    /// Список героев, управлямых этим скриптом 
    /// </summary>
    List<Hero> heroes;

    /// <summary>
    /// удаляет всех героев
    /// </summary>
    internal void DestroyHeroes()
    {
        foreach (var item in heroes)
        {
            if (item != null)
            {
                item.SelfDestruction();
            }
        }
    }

    /// <summary>
    /// БД героев
    /// </summary>
    List<GameObject> heroesDB;

    /// <summary>
    /// Создает героев и помещает их на точках спавна
    /// </summary>
    List<Hero> CreateRandomHeroes(Point[] points)
    {
        List<Hero> list = new List<Hero>();

        //для каждой точки
        for (int i = 0; i < points.Length; i++)
        {
            //загружаем го
            GameObject go = GetRandomHero();
            //спавним
            Hero hero = UtilsManager.Spawn(go, points[i].transform.position).GetComponent<Hero>();
            //добавляем в список
            list.Add(hero);
        }

        return list;
    }

    /// <summary>
    /// Возвращает рандомного героя
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomHero()
    {
        if (heroesDB == null)
        {
            heroesDB = new List<GameObject>();

            foreach (var item in Resources.LoadAll("TestObjects/Heroes"))
            {
                heroesDB.Add(item as GameObject);
            }
        }

        return heroesDB[Random.Range(0, heroesDB.Count)];
    }

    /// <summary>
    /// Возвращает имя случайного героя и удаляет его
    /// </summary>
    /// <returns></returns>
    internal string GetRandomHeroName()
    {
        string name = "";

        while (string.IsNullOrEmpty(name))
        {
            int rand = Random.Range(0, heroes.Count);
            if (heroes[rand] == null)
            {
                heroes.RemoveAt(rand);
            }
            else if (heroes[rand].gameObject.GetComponent<HeroCircleSelector>().IsSelected)
            {
                break;
            }
            else
            {
                //выбираем героя
                Hero hero = heroes[rand];
                //помечаем его выбранным
                heroes[rand].gameObject.GetComponent<HeroCircleSelector>().IsSelected = true;
                //запоминаем его имя
                name = hero.Info.Name;
                //удаляем его из списка
                heroes.RemoveAt(rand);
                //уничтожаем его (временно)
                //потом должен уничтожаться только после того, как Хранитель заберет его с круга
                hero.SelfDestruction();
            }
        }
        //возвращаем имя
        return name;
    }

    /// <summary>
    /// Проверяет, все ли герои розданы
    /// </summary>
    /// <returns></returns>
    public bool AllHeroesDistributed()
    {
        if (heroes.Count <= 2)
        {
            return true;
        }
        return false;
    }
}