using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneConfig
{
    /// <summary>
    /// Создаем словарь репозиториев
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<Type, Repository> CreateAllRepositories();

    /// <summary>
    /// Создаем словарь итераторов
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<Type, Interactor> CreateAllInteractors();

    /// <summary>
    /// Название сцены
    /// </summary>
    public abstract string SceneName { get; }

    /// <summary>
    /// Создание одного интерактора
    /// </summary>
    public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);

        interactorsMap[type] = interactor;
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

}
