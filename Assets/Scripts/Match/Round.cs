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
        field = UtilsManager.Spawn("TestObjects/PlayingField").GetComponent<Field>();
    }
}