using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    /// <summary>
    /// Событие: игра запущена
    /// </summary>
    public static event Action OnGameInitializedEvent;

    /// <summary>
    /// Менеджер сцен
    /// </summary>
    public static SceneController sceneManager { get; private set; }

    /// <summary>
    /// Запускаем игру
    /// </summary>
    public static void Run()
    {
        sceneManager = new SceneController();
        Coroutines.StartRoutine(InitializeGameRoutine());
    }

    /// <summary>
    /// Инициализатор игры
    /// </summary>
    /// <returns></returns>
    static IEnumerator InitializeGameRoutine()
    {
        sceneManager.InitScenesMap();
        yield return sceneManager.LoadCurrentSceneAsync();
        OnGameInitializedEvent?.Invoke();
    }

    /// <summary>
    /// Возвращает контроллер
    /// </summary>
    public static T GetController<T>() where T : Controller
    {
        return sceneManager.GetController<T>();
    }

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }
}
