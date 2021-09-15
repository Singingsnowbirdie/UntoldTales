using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//обертка над менеджером сцен от юнити

public class SceneManagerExtension : MonoBehaviour
{
    /// <summary>
    /// Событие: сцена загружена
    /// </summary>
    public event Action<Scene> OnSceneLoadedEvent;

    /// <summary>
    /// Текущая сцена
    /// </summary>
    public Scene Scene { get; private set; }

    /// <summary>
    /// Происходит загрузка
    /// </summary>
    public bool IsLoading { get; private set; }

    /// <summary>
    /// Карта конфигов сцен
    /// </summary>
    Dictionary<string, SceneConfig> sceneConfigMap;

    /// <summary>
    /// Конструктор
    /// </summary>
    public SceneManagerExtension()
    {
        sceneConfigMap = new Dictionary<string, SceneConfig>();
        InitScenesMap();
    }

    /// <summary>
    /// Инициализатор карты сцен
    /// </summary>
    public void InitScenesMap()
    {
        sceneConfigMap[SceneConfigExample.SCENENAME] = new SceneConfigExample();
    }
    /// <summary>
    /// Метод доступа (загрузка текущей сцены)
    /// </summary>
    public Coroutine LoadCurrentSceneAsync()
    {
        //на всякий пожарный
        if (IsLoading)
        {
            throw new Exception("Scene is loading now");
        }

        //спрашиваем имя текущей сцены у юнити
        var sceneName = SceneManager.GetActiveScene().name;
        var config = sceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
    }

    /// <summary>
    /// Обертка над загрузчиком и инициализатором (текущая сцена)
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
    {
        IsLoading = true;
        //уже загружена, поэтому только инициализируем
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));
        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }

    /// <summary>
    /// Обертка над загрузчиком и инициализатором (новая сцена)
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
    {
        IsLoading = true;
        yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));
        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }

    /// <summary>
    /// Метод доступа (загрузка новой сцены)
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public Coroutine LoadNewSceneAsync(string sceneName)
    {
        //на всякий пожарный
        if (IsLoading)
        {
            throw new Exception("Scene is loading now");
        }

        var config = sceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
    }

    /// <summary>
    /// Загрузчик сцены
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            //здесь будем показывать заставку
            yield return null;
        }
        async.allowSceneActivation = true;
    }

    /// <summary>
    /// Инициализатор сцены
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        Scene = new Scene(sceneConfig);
        yield return Scene.InitializeAsync();
    }

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetRepository<T>() where T : Repository
    {
        return Scene.GetRepository<T>();
    }

    /// <summary>
    /// Возвращает интерактор
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetInteractor<T>() where T : Interactor
    {
        return Scene.GetInteractor<T>();
    }
}
