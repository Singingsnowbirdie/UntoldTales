using System.Collections;
using UnityEngine;

public class HeroesCircleStage : MatchStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public HeroesCircleStage(Match match)
    {
        this.match = match;
        heroesCircle = UtilsManager.Spawn("TestObjects/HeroesCircle").GetComponent<HeroesCircle>();
        match.HeroesCircle = heroesCircle;
        StageName = "Круг Героев";
    }

    /// <summary>
    /// Круг героев (скрипт)
    /// </summary>
    HeroesCircle heroesCircle;

    /// <summary>
    /// Режим: на время
    /// </summary>
    public bool IsTiming { get; set; }

    /// <summary>
    /// Матч
    /// </summary>
    private readonly Match match;

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public override void EnterStage()
    {
        //спавним героев
        heroesCircle.CreateRandomHeroes();
        //если круг на время
        if (IsTiming)
        {
            //запускаем распределение героев между AI игроками
            UtilsManager.StartRoutine(HeroesDistribution(UtilsManager.StartRoutine(StageTimer())));
        }
        //вызываем событие
        base.EnterStage();
    }

    /// <summary>
    /// Распределяет героев между AI
    /// </summary>
    /// <returns></returns>
    private IEnumerator HeroesDistribution(Coroutine timer)
    {
        //раздаем всем AI по герою
        foreach (var item in match.Players.GetAIPlayers())
        {
            //делаем паузу
            yield return new WaitForSeconds(Random.Range(0f, 3f));
            //отдаем случайного героя AI
            item.SelectedHeroName = heroesCircle.GetRandomHero();
        }

        //проверяем, все ли герои розданы
        if (heroesCircle.AllHeroesIsSelected())
        {
            //отключаем таймер
            UtilsManager.StopRoutine(timer);
            //завершаем стадию
            ExitStage();
        }
    }

    /// <summary>
    /// Таймер этапа
    /// </summary>
    /// <returns></returns>
    private IEnumerator StageTimer()
    {
        //ждем 15 секунд
        yield return new WaitForSeconds(15f);
        //проверяем, все ли герои розданы
        if (!heroesCircle.AllHeroesIsSelected())
        {
            ForcedHeroesDistribution();
        }
    }

    /// <summary>
    /// Насильно распихивает случайных героев игрокам, не выбравшим себе героя 
    /// </summary>
    private void ForcedHeroesDistribution()
    {
        foreach (var item in match.Players.GetPlayers())
        {
            if (string.IsNullOrEmpty(item.SelectedHeroName))
            {
                item.SelectedHeroName = heroesCircle.GetRandomHero();
            }
        }
        ExitStage();
    }
}
