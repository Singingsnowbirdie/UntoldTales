using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    /// <summary>
    /// База контроллеров
    /// </summary>
    ControllersDB controllersBase;

    /// <summary>
    /// База репозиториев
    /// </summary>
    RepositoriesDB repositoriesBase;

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
    public SceneConfig SceneConfig { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="config"></param>
    public Scene(SceneConfig config)
    {
        SceneConfig = config;
        controllersBase = new ControllersDB(config);
        repositoriesBase = new RepositoriesDB(config);
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    /// <returns></returns>
    public Coroutine InitializeAsync()
    {
        return UtilsManager.StartRoutine(InitializeRoutine());
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
        SceneConfig.Initialize();
        yield return null;

        repositoriesBase.SendOnStartToAllRepositories();
        controllersBase.SendOnStartToAllControllers();
    }

    /// <summary>
    /// Старт
    /// </summary>
    internal void OnStart()
    {
        SceneConfig.OnStart();
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
