using UnityEngine;

public class Round
{
    /// <summary>
    /// Поле
    /// </summary>
    protected Field field;

    /// <summary>
    /// Запускает матч
    /// </summary>
    public virtual void StartRound()
    {
        //создаем поле
        GameObject fieldGO = Object.Instantiate(Resources.Load("TestObjects/PlayingField")) as GameObject;
        field = fieldGO.GetComponent<Field>();
    }
}