using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    /// <summary>
    /// Поле
    /// </summary>
    protected Field field;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Round()
    {
        field = UtilsManager.Spawn("TestObjects/PlayingField").GetComponent<Field>();
    }
}