using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// База репозиториев
/// </summary>

public class Repositories : MonoBehaviour
{
    /// <summary>
    /// Карта репозиториев
    /// </summary>
    Dictionary<Type, Repository> repositoriesMap;

    /// <summary>
    /// Сцена, для которой создана эта база
    /// </summary>
    SceneConfig sceneConfig;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Repositories(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
    }

    /// <summary>
    /// Создаем все репозитории
    /// </summary>
    public void CreateAllRepositories()
    {
        repositoriesMap = sceneConfig.CreateRepositories();
    }

    /// <summary>
    /// Вызываем OnCreate на всех репозиториях
    /// </summary>
    public void SendOnCreateToAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.OnCreate();
        }
    }

    /// <summary>
    /// Вызываем Initialize на всех репозиториях
    /// </summary>
    public void InitializeAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.Initialize();
        }
    }

    /// <summary>
    /// Вызываем OnStart на всех репозиториях
    /// </summary>
    public void SendOnStartToAllRepositories()
    {
        var allRepositories = this.repositoriesMap.Values;
        foreach (var repository in allRepositories)
        {
            repository.OnStart();
        }
    }

    /// <summary>
    /// Возвращает нужный репозиторий
    /// </summary>
    /// <typeparam name="T">Тип</typeparam>
    /// <returns>Репозиторий</returns>
    public T GetRepository<T>() where T : Repository
    {
        var type = typeof(T);
        return (T)repositoriesMap[type];
    }
}
