using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управляет игрой

public class Game : MonoBehaviour
{
    /// <summary>
    /// Загрузчик сцены
    /// </summary>
    public static SceneLoader sceneLoader { get; private set; }

    /// <summary>
    /// Запускаем игру
    /// </summary>
    public static void Run()
    {
        //запускаем инициализатор игры
        UtilsManager.StartRoutine(InitializeGameRoutine());
    }

    /// <summary>
    /// Инициализатор игры
    /// </summary>
    /// <returns></returns>
    static IEnumerator InitializeGameRoutine()
    {
        //инициализируем контроллер сцен
        sceneLoader = new SceneLoader();
        //ждем, пока загрузится текущая сцена
        yield return sceneLoader.LoadCurrentSceneAsync();
    }

    /// <summary>
    /// Возвращает контроллер
    /// </summary>
    public static T GetController<T>() where T : IController
    {
        return sceneLoader.GetController<T>();
    }

    /// <summary>
    /// Возвращает репозиторий
    /// </summary>
    public static T GetRepository<T>() where T : Repository
    {
        return sceneLoader.GetRepository<T>();
    }

}
