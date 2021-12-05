using System;
using System.Collections.Generic;
using UnityEngine;

//контроллер сцены

public abstract class Scene : MonoBehaviour
{
    /// <summary>
    /// Все контроллеры
    /// </summary>
    protected Dictionary<Type, IController> controllers;

    /// <summary>
    /// Все герои
    /// </summary>
    [SerializeField] CharacterInfo[] heroesDB;

    private void Awake()
    {
        heroesDB = Resources.LoadAll<CharacterInfo>("TestObjects/Heroes");
        CreateControllers();
    }

    protected virtual void Start()
    {
        //стартуем все контроллеры
        foreach (var item in controllers)
        {
            item.Value.OnStart();
        }
    }

    /// <summary>
    /// Создает все необходимые контроллеры
    /// </summary>
    public abstract void CreateControllers();

    /// <summary>
    /// Возвращает контроллер по имени
    /// </summary>
    internal T GetController<T>() where T : IController
    {
        return GetController<T>();
    }

    /// <summary>
    /// Возвращает инфо всех героев заданного уровня
    /// </summary>
    internal List<CharacterInfo> GetHeroes(int rank)
    {
        List<CharacterInfo> selectedHeroes = new List<CharacterInfo>();

        foreach (var item in heroesDB)
        {
            if (item.Rank == rank)
            {
                selectedHeroes.Add(item);
            }
        }
        return selectedHeroes;
    }

    /// <summary>
    /// Создание одного контроллера
    /// </summary>
    public void CreateController<T>(Dictionary<Type, IController> controllers) where T : IController, new()
    {
        var controller = new T();
        var type = typeof(T);
        controllers[type] = controller;
    }

    private void OnDestroy()
    {
        //отписываем все контроллеры от событий
        foreach (var item in controllers)
        {
            item.Value.OnExit();
        }
    }

    /// <summary>
    /// Возвращает инфо героя по ID
    /// </summary>
    internal CharacterInfo GetHeroInfo(int heroID)
    {
        foreach (var item in heroesDB)
        {
            if (item.ID == heroID)
            {
                return item;
            }
        }
        return null;
    }
}
