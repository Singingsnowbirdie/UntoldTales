using System;
using UnityEngine;

public class Round
{
    /// <summary>
    /// Поле
    /// </summary>
    protected Field field;

    /// <summary>
    /// Контроллер отряда
    /// </summary>
    SquadController squadController;

    /// <summary>
    /// Запускает матч
    /// </summary>
    public virtual void StartRound()
    {
        //создаем поле
        field = UtilsManager.Spawn("TestObjects/PlayingField").GetComponent<Field>();
        //создаем отряд
        squadController = new SquadController();
    }
}