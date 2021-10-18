public class PvERound : Round
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="pveRoundsCounter"></param>
    public PvERound(int pveRoundsCounter)
    {
        mobs = new Mobs(pveRoundsCounter, field.GetEnemyPoints());
    }

    /// <summary>
    /// Мобы
    /// </summary>
    Mobs mobs;

}
