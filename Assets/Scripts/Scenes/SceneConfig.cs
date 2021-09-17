using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Конфиг конкретной сцены

public abstract class SceneConfig
{
    /// <summary>
    /// Словарь репозиториев
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<Type, Repository> CreateAllRepositories();

    /// <summary>
    /// Словарь контроллеров
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<Type, Controller> CreateAllControllers();

    /// <summary>
    /// Название сцены
    /// </summary>
    public abstract string SceneName { get; }

    /// <summary>
    /// Создание одного контроллера
    /// </summary>
    public void CreateController<T>(Dictionary<Type, Controller> controllersMap) where T : Controller, new()
    {
        var controller = new T();
        var type = typeof(T);

        controllersMap[type] = controller;
    }

    /// <summary>
    /// Создание одного репозитория
    /// </summary>
    public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
    {
        var repository = new T();
        var type = typeof(T);

        repositoriesMap[type] = repository;
    }


    /// <summary>
    /// Инициализатор
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Старт сцены
    /// </summary>
    public abstract void OnStart();
}
