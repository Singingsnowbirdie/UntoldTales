using System.Collections.Generic;
using UnityEngine;

public class HeroesCircle : MonoBehaviour
{
    /// <summary>
    /// Точки, над которыми будут спавниться случайные герои
    /// </summary>
    Point[] points;

    /// <summary>
    /// Репозиторий всех существующих героев
    /// </summary>
    List<Hero> heroesDB;

    private void OnEnable()
    {
        PlaceHeroes();
    }

    /// <summary>
    /// Размещаем всех героев
    /// </summary>
    private void PlaceHeroes()
    {
        //получаем все точки в массив
        points = gameObject.GetComponentsInChildren<Point>();
        //получаем ссылку на репозиторий всех героев
        heroesDB = Game.GetRepository<HeroesRepository>().Heroes;
        //спавним героев
        foreach (var item in points) PlaceHero(item);
    }

    /// <summary>
    /// Спавнит случайного героя и помещает его на точку
    /// </summary>
    /// <param name="item"></param>
    private void PlaceHero(Point point)
    {
        //спавним болванку
        GameObject go = UtilsManager.Spawn("TestObjects/HeroesCircle");
        //помещаем ее над точкой
        go.transform.position = point.transform.position;
        //навешиваем на нее скрипт
        go.AddComponent<Hero> ();
    }
}
