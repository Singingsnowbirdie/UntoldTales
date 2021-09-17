﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Загрузчик сцен

public class SceneLoader
{
    /// <summary>
    /// Событие: сцена загружена
    /// </summary>
    public event Action<Scene> OnSceneLoadedEvent;

    /// <summary>
    /// Текущая сцена
    /// </summary>
    public Scene CurrentScene { get; private set; }

    /// <summary>
    /// Происходит загрузка
    /// </summary>
    public bool IsLoading { get; private set; }

    /// <summary>
    /// Конфиги всех сцен
    /// </summary>
    Dictionary<string, SceneConfig> ScenesConfigsMap;

    /// <summary>
    /// Конструктор
    /// </summary>
    public SceneLoader()
    {
        //инициализируем менеджер ввода

        //создаем карту сцен
        ScenesConfigsMap = new Dictionary<string, SceneConfig>();
        //инициалиируем ее
        InitScenesMap();
    }

    /// <summary>
    /// Инициализатор карты сцен
    /// </summary>
    public void InitScenesMap()
    {
        //интро
        ScenesConfigsMap[SceneConfig_IntroScene.SCENENAME] = new SceneConfig_IntroScene();
        //сцена раунда
        ScenesConfigsMap[SceneConfig_RoundScene.SCENENAME] = new SceneConfig_RoundScene();
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
        var config = ScenesConfigsMap[sceneName];
        return CoroutinesManager.StartRoutine(LoadCurrentSceneRoutine(config));
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
        yield return CoroutinesManager.StartRoutine(InitializeSceneRoutine(sceneConfig));
        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(CurrentScene);
    }

    /// <summary>
    /// Обертка над загрузчиком и инициализатором (новая сцена)
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
    {
        IsLoading = true;
        yield return CoroutinesManager.StartRoutine(LoadSceneRoutine(sceneConfig));
        yield return CoroutinesManager.StartRoutine(InitializeSceneRoutine(sceneConfig));
        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(CurrentScene);
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

        var config = ScenesConfigsMap[sceneName];
        return CoroutinesManager.StartRoutine(LoadNewSceneRoutine(config));
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
        CurrentScene = new Scene(sceneConfig);
        yield return CurrentScene.InitializeAsync();
    }

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetRepository<T>() where T : Repository
    {
        return CurrentScene.GetRepository<T>();
    }

    /// <summary>
    /// Возвращает контроллер
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetController<T>() where T : Controller
    {
        return CurrentScene.GetController<T>();
    }
}