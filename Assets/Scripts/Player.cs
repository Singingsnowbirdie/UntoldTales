using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player(int id)
    {
        ID = id;
        IsAI = true; //временно
    }

    /// <summary>
    /// Управляется ли этот "игрок" ИИ
    /// </summary>
    public bool IsAI { get; set; }

    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    public int ID { get; set; }
}
