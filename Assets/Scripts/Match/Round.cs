using UnityEngine;

public class Round : MonoBehaviour
{
    /// <summary>
    /// Поле
    /// </summary>
    protected Field field;

    /// <summary>
    /// Создает поле
    /// </summary>
    public void CreateField()
    {
        field = UtilsManager.Spawn("TestObjects/PlayingField").GetComponent<Field>();
    }

    /// <summary>
    /// Запускает матч
    /// </summary>
    public virtual void StartRound()
    {
        //создаем поле
        CreateField();
    }
}