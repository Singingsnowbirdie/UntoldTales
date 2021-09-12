using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    /// <summary>
    /// База интеракторов
    /// </summary>
    InteractorsBase interactorsBase;

    /// <summary>
    /// База репозиториев
    /// </summary>
    RepositoriesBase repositoriesBase;

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    internal T GetRepository<T>() where T : Repository
    {
        return repositoriesBase.GetRepository<T>();
    }
    
    /// <summary>
    /// Возвращает интерактор
    /// </summary>
    internal T GetInteractor<T>() where T : Interactor
    {
        return interactorsBase.GetInteractor<T>();
    }

    /// <summary>
    /// Конфиг
    /// </summary>
    SceneConfig sceneConfig;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="config"></param>
    public Scene(SceneConfig config)
    {
        sceneConfig = config;
        interactorsBase = new InteractorsBase(config);
        repositoriesBase = new RepositoriesBase(config);
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitializeRoutine()
    {
        repositoriesBase.CreateAllRepositories();
        interactorsBase.CreateAllInteractors();
        yield return null;

        repositoriesBase.SendOnCreateToAllRepositories();
        interactorsBase.SendOnCreateToAllInteractors();
        yield return null;

        repositoriesBase.InitializeAllRepositories();
        interactorsBase.InitializeAllInteractors();
        yield return null;

        repositoriesBase.SendOnStartToAllRepositories();
        interactorsBase.SendOnStartToAllInteractors();
    }
}
