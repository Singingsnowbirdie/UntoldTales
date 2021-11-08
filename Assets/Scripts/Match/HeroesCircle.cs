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

        //все герои
        Object[] heroesDB = Resources.LoadAll("TestObjects/Heroes");

        //для каждой точки
        for (int i = 0; i < points.Length; i++)
        {
            //индекс случайного героя 
            int rand = Random.Range(0, heroesDB.Length);
            //спавним рандомного героя
            Hero hero = UtilsManager.Spawn(heroesDB[rand] as GameObject, points[i].transform.position).GetComponent<Hero>();
            //навешиваем селектор на героя
            HeroCircleSelector selector = hero.gameObject.AddComponent<HeroCircleSelector>();
            //передаем данные в селектор
            selector.SelectorID = i;
            selector.HeroesCircle = this;
            //добавляем героя в коллекцию
            heroes.Add(selector);
        }
    }

    /// <summary>
    /// Удаляет героя из коллекции (после того, как его выбрал себе игрок)
    /// </summary>
    /// <param name="selectorID"></param>
    internal void RemoveHero(int selectorID)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].GetComponent<HeroCircleSelector>().SelectorID == selectorID)
            {
                heroes.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Всех героев разобрали
    /// </summary>
    internal bool AllHeroesIsSelected()
    {
        if (heroes.Count <= 2)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Возвращает имя случайного героя и уничтожает его
    /// </summary>
    /// <returns></returns>
    internal string GetRandomHero()
    {
        //имя выбранного героя
        string heroName = "";

        while (string.IsNullOrEmpty(heroName))
        {
            //выбираем случайного героя
            HeroCircleSelector hero = heroes[Random.Range(0, heroes.Count)];
            heroName = hero.TryToSelect();
        }
        //возвращаем имя
        return heroName;
    }
}

