using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// База контроллеров
/// </summary>

public class 
    Controllers : MonoBehaviour
{
    /// <summary>
    /// Карта контроллеров
    /// </summary>
    Dictionary<Type, IController> controllersMap;

    /// <summary>
    /// Сцена, для которой создана эта база
    /// </summary>
    SceneConfig sceneConfig;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Controllers(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
    }

    /// <summary>
    /// Создаем все контроллеры
    /// </summary>
    public void CreateAllControllers()
    {
        controllersMap =  sceneConfig.CreateControllers();
    }

    /// <summary>
    /// Вызываем OnStart на всех контроллерах
    /// </summary>
    public void SendOnStartToAllControllers()
    {
        var allControllers = this.controllersMap.Values;
        foreach (var controller in allControllers)
        {
            controller.OnStart();
        }
    }

    /// <summary>
    /// Вызываем OnExit на всех контроллерах
    /// </summary>
    public void SendOnExitToAllControllers()
    {
        var allControllers = this.controllersMap.Values;
        foreach (var controller in allControllers)
        {
            controller.OnExit();
        }
    }

    /// <summary>
    /// Возвращает нужный контроллер
    /// </summary>
    public T GetController<T>() where T : IController
    {
        var type = typeof(T);
        return (T)controllersMap[type];
    }
}
