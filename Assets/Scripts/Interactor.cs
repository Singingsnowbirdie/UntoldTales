using UnityEngine;

//Этот класс работает с данными

public abstract class Interactor : MonoBehaviour
{
    /// <summary>
    /// Срабатывает при создании
    /// </summary>
    public virtual void OnCreate() { }

    /// <summary>
    /// Этот метод будет инициализировать все интеракторы
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Срабатывает при старте
    /// </summary>
    public virtual void OnStart() { }

}
