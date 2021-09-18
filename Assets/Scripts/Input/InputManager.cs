using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Менеджер пользовательского ввода (тестовый)

public class InputManager : MonoBehaviour
{
    void Update()
    {
        //Жмем пробел = переходим на сцену раунда
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Game.sceneLoader.LoadNewSceneAsync("RoundScene");
        }
    }
}
