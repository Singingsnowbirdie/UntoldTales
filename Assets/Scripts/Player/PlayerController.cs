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
        //базовая инициализация
        base.Initialize();
        //создаем объект "игрок"
        var goPlayer = new GameObject("Player");
        //навешиваем на него скрипт "игрок"
        Player = goPlayer.AddComponent<Player>();
    }
}
