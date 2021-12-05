using System.Collections.Generic;
using UnityEngine;

public class HeroesCircle : MonoBehaviour
{
    /// <summary>
    /// Герои на круге
    /// </summary>
    List<HeroCircleSelector> heroes;

    private void OnEnable()
    {
        heroes = new List<HeroCircleSelector>();
        //подписываемся на выход из состояния
        EventManager.OnStageExit += OnStageExit;
    }

    /// <summary>
    /// При завершении стадии круга героев, дестроим круг
    /// </summary>
    /// <param name="obj"></param>
    private void OnStageExit(IStage stage)
    {
        if (stage is HeroesCircleStage)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Создает героев и помещает их на точках спавна
    /// </summary>
    public void CreateRandomHeroes()
    {
        //все точки
        Point[] points = gameObject.GetComponentsInChildren<Point>();

        //все герои первого уровня
        List<CharacterInfo> heroesDB = FindObjectOfType<Scene>().GetHeroes(1);

        //для каждой точки
        for (int i = 0; i < points.Length; i++)
        {
            //выбираем случайного героя 
            int rand = Random.Range(0, heroesDB.Count);
            //спавним его префаб
            GameObject hero = UtilsManager.Spawn(heroesDB[rand].Prefab, points[i].transform.position);
            //навешиваем селектор на префаб
            HeroCircleSelector selector = hero.AddComponent<HeroCircleSelector>();
            //передаем данные в селектор
            selector.HeroID = heroesDB[rand].ID;
            //добавляем героя в коллекцию
            heroes.Add(selector);
        }
    }

    /// <summary>
    /// Всех героев разобрали
    /// </summary>
    internal bool AllHeroesIsSelected()
    {
        int freeHeroes = 10;
        foreach (var item in heroes)
        {
            if (item.IsSelected)
            {
                freeHeroes--;
                if (freeHeroes == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Возвращает ID случайного героя
    /// </summary>
    /// <returns></returns>
    internal int GetRandomHero()
    {
        int heroID = 0;

        while (heroID == 0)
        {
            //выбираем случайного героя
            HeroCircleSelector hero = heroes[Random.Range(0, heroes.Count)];
            heroID = hero.TryToSelect();
        }
        return heroID;
    }
}

