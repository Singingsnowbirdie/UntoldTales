using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Менеджер пользовательского ввода (тестовый)

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("InputManagerTest");
        }
    }
}
