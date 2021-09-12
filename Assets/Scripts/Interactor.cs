using UnityEngine;

//Этот класс работает с данными

public abstract class Interactor : MonoBehaviour
{
    /// <summary>
    /// Срабатывает после созданиия всех интеракторов и репозиториев
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
