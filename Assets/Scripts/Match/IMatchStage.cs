using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatchStage
{
    /// <summary>
    /// Вход в состояние
    /// </summary>
    void Enter();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    void Exit();

    /// <summary>
    /// апдейт
    /// </summary>
    void Update();
}
