using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesCircleStage : MatchStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public HeroesCircleStage(Match match)
    {
        this.match = match;
        players = match.Players;
        heroesCircle = match.HeroesCircle;
        StageName = "Круг Героев (на время)";
    }

    /// <summary>
    /// Круг героев (скрипт)
    /// </summary>
    HeroesCircle heroesCircle;

    /// <summary>
    /// Матч
    /// </summary>
    readonly Match match;

    /// <summary>
    /// Все игроки
    /// </summary>
    Players players;

    /// <summary>
    /// Таймер окончания Круга Героев
    /// </summary>
    Coroutine timer;

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        //запускаем таймер
        timer = UtilsManager.StartRoutine(StageTimer());
        //запускаем распределение героев между AI игроками
        UtilsManager.StartRoutine(HeroesDistribution());
    }

    /// <summary>
    /// Распределяет героев между AI
    /// </summary>
    /// <returns></returns>
    private IEnumerator HeroesDistribution()
    {
        //создаем временный список
        List<AIPlayer> AIPlayers = players.GetAIPlayers();

        //раздаем всем AI по герою
        foreach (var item in AIPlayers)
        {
            //делаем паузу
            float pause = Random.Range(0f, 3f);
            yield return new WaitForSeconds(pause);
            //отдаем случайного героя AI
            item.SelectedHeroName = heroesCircle.GetRandomHeroName();
        }

        //проверяем, все ли герои розданы
        if (heroesCircle.AllHeroesDistributed())
        {
            //отключаем таймер
            UtilsManager.StopRoutine(timer);
            //завершаем стадию
            Exit();
        }
    }

    private IEnumerator StageCompletion()
    {
        //отключаем круг героев
        heroesCircle.gameObject.SetActive(false);
        yield return null;
        //завершаем стадию
        UtilsManager.StartRoutine(StageCompletion());
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
        if (!heroesCircle.AllHeroesDistributed())
        {
            ForcedHeroesDistribution();
        }
        yield return null;
        //завершаем стадию
        UtilsManager.StartRoutine(StageCompletion());
    }

    /// <summary>
    /// Насильно распихивает случайных героев игрокам, не выбравшим себе героя 
    /// </summary>
    private void ForcedHeroesDistribution()
    {
        foreach (var item in players.GetPlayers())
        {
            if (string.IsNullOrEmpty(item.SelectedHeroName))
            {
                item.SelectedHeroName = heroesCircle.GetRandomHeroName();
            }
        }
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public override void Exit()
    {
        //удаляем оставшихся героев
        heroesCircle.DestroyHeroes();

        //выключаем круг
        heroesCircle.gameObject.SetActive(false);

        //отрабатываем код из родительского скрипта
        base.Exit();

        //меняем состояние
        match.ChangeStage();
    }

}
