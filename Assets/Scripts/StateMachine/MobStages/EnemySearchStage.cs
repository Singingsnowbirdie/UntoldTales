using UnityEngine;

//Состояние моба: поиск противника

public class EnemySearchStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public EnemySearchStage(Mob mob)
    {
        this.mob = mob;
    }

    /// <summary>
    /// Этот моб
    /// </summary>
    private Mob mob;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public void Enter()
    {
        EnemySearch();
    }

    /// <summary>
    /// Выход
    /// </summary>
    public void Exit() { }

    public string StageName { get; set; }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void EnemySearch()
    {
        //если уже есть цель
        if (mob.CurrentTarget)
        {
            //переходим к следующему состоянию
            Mob.ChangeStage();
        }
        //ищем подходящую цель
    }
}

