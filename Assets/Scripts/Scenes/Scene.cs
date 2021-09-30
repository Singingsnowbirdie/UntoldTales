using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    /// <summary>
    /// База контроллеров
    /// </summary>
    ControllersBase controllersBase;

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
    /// Возвращает контроллер
    /// </summary>
    internal T GetController<T>() where T : IController
    {
        return controllersBase.GetController<T>();
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
        controllersBase = new ControllersBase(config);
        repositoriesBase = new RepositoriesBase(config);
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    /// <returns></returns>
    public Coroutine InitializeAsync()
    {
        return CoroutinesManager.StartRoutine(InitializeRoutine());
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitializeRoutine()
    {
        repositoriesBase.CreateAllRepositories();
        controllersBase.CreateAllControllers();
        yield return null;

        repositoriesBase.SendOnCreateToAllRepositories();
        controllersBase.SendOnCreateToAllControllers();
        yield return null;

        repositoriesBase.InitializeAllRepositories();
        controllersBase.InitializeAllControllers();
        sceneConfig.Initialize();
        yield return null;

        repositoriesBase.SendOnStartToAllRepositories();
        controllersBase.SendOnStartToAllControllers();
    }

    /// <summary>
    /// Старт
    /// </summary>
    internal void OnStart()
    {
        sceneConfig.OnStart();
    }

    /// <summary>
    /// Выход
    /// </summary>
    internal void OnExit()
    {
        //вызываем на всех контроллерах, чтобы отписаться от всех тамошних событий
        controllersBase.SendOnExitToAllControllers();
    }
}
