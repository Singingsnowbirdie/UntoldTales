using System;
using System.Collections.Generic;

//Конфиг конкретной сцены

public abstract class SceneConfig
{
    /// <summary>
    /// Создает и возвращает коллекцию репозиториев
    /// </summary>
    public abstract Dictionary<Type, Repository> CreateRepositories();

    /// <summary>
    /// Создает и возвращает коллекцию контроллеров
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<Type, IController> CreateControllers();

    /// <summary>
    /// Создание одного контроллера
    /// </summary>
    public void CreateController<T>(Dictionary<Type, IController> controllersMap) where T : IController, new()
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

    public virtual void OnStart()
    {
        //действия, которые нужно произвозить при старте сцены (таких может и не быть)
    }
}
