using System.Collections;
using UnityEngine;

public class Scene
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="config"></param>
    public Scene(SceneConfig config)
    {
        SceneConfig = config;
        controllers = new Controllers(config);
        repositories = new Repositories(config);
    }

    /// <summary>
    /// Конфиг
    /// </summary>
    public SceneConfig SceneConfig { get; set; }

    /// <summary>
    /// Контроллеры сцены
    /// </summary>
    Controllers controllers;

    /// <summary>
    /// Репозитории сцены
    /// </summary>
    Repositories repositories;

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    internal T GetRepository<T>() where T : Repository
    {
        return repositories.GetRepository<T>();
    }
    
    /// <summary>
    /// Возвращает контроллер
    /// </summary>
    internal T GetController<T>() where T : IController
    {
        return controllers.GetController<T>();
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
        //Создаем все репопзитории и контроллеры
        repositories.CreateAllRepositories();
        controllers.CreateAllControllers();
        yield return null;

        //стартуем все репозитории и контроллеры
        repositories.SendOnStartToAllRepositories();
        controllers.SendOnStartToAllControllers();
    }

    /// <summary>
    /// Старт
    /// </summary>
    internal void StartScene()
    {
        SceneConfig.OnStart();
    }

    /// <summary>
    /// Выход
    /// </summary>
    internal void UnsubscribeAll()
    {
        //вызываем на всех контроллерах, чтобы отписаться от всех тамошних событий
        controllers.SendOnExitToAllControllers();
    }
}
