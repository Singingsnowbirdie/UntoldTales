using System;
using UnityEngine;

public abstract class Controller
{
    /// <summary>
    /// Срабатывает после создания всех контроллеров и репозиториев
    /// </summary>
    public virtual void OnCreate() { }

    /// <summary>
    /// Этот метод будет инициализировать все контроллеры
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Срабатывает при старте
    /// </summary>
    public virtual void OnStart() { }

    /// <summary>
    /// срабатывает при выходе
    /// </summary>
    public virtual void OnExit() { }
}
