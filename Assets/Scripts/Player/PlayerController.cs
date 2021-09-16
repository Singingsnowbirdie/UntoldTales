using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Контроллер игрока

public class PlayerController : Controller
{
    /// <summary>
    /// Игрок
    /// </summary>
    public Player Player { get; private set; }

    /// <summary>
    /// Инициализация
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        var goPlayer = new GameObject("Player");
        Player = goPlayer.AddComponent<Player>();
    }
}
