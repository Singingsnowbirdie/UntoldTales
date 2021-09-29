﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Фаза раунда
/// </summary>

public interface IRoundStage
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
