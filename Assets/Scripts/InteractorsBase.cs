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
    /// Конструктор
    /// </summary>
    public InteractorsBase()
    {
        interactorsMap = new Dictionary<Type,Interactor>();
    }

    /// <summary>
    /// Создаем все интеракторы
    /// </summary>
    public void CreateAllInteractors()
    {
        CreateInteractor<WalletInteractor>();
    }

    /// <summary>
    /// Создаем один интерактор
    /// </summary>
    /// <typeparam name="T"></typeparam>
    void CreateInteractor<T>() where T:Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);
        interactorsMap[type] = interactor;
    }
}
