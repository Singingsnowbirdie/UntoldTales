using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// База интеракторов
/// </summary>

public class InteractorsBase : MonoBehaviour
{
    /// <summary>
    /// Карта интеракторов
    /// </summary>
    Dictionary<Type, Interactor> interactorsMap;

    /// <summary>
    /// Сцена, для которой создана эта база
    /// </summary>
    SceneConfig sceneConfig;

    /// <summary>
    /// Конструктор
    /// </summary>
    public InteractorsBase(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
    }

    /// <summary>
    /// Создаем все интеракторы
    /// </summary>
    public void CreateAllInteractors()
    {
        interactorsMap =  sceneConfig.CreateAllInteractors();
    }

    /// <summary>
    /// Вызываем OnCreate на всех интеракторах
    /// </summary>
    public void SendOnCreateToAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.OnCreate();
        }
    }

    /// <summary>
    /// Вызываем Initialize на всех интеракторах
    /// </summary>
    public void InitializeAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.Initialize();
        }
    }

    /// <summary>
    /// Вызываем OnStart на всех интеракторах
    /// </summary>
    public void SendOnStartToAllInteractors()
    {
        var allInteractors = this.interactorsMap.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.OnStart();
        }
    }

    /// <summary>
    /// Возвращает нужный интерактор
    /// </summary>
    /// <typeparam name="T">Тип</typeparam>
    /// <returns>Интерактор</returns>
    public T GetInteractor<T>() where T : Interactor
    {
        var type = typeof(T);
        return (T)interactorsMap[type];
    }
}
