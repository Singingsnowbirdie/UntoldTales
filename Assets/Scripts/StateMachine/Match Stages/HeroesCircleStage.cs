using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Круг героев
//Первый и последний этапы начальной стадии матча
//Первый этап: на время
//Последний этап: по очереди

public class HeroesCircleStage : Stage
{
    /// <summary>
    /// Круг героев (скрипт)
    /// </summary>
    public HeroesCircle HeroesCircle { get; set; }

    /// <summary>
    /// родительская машина состояний
    /// </summary>
    readonly MatchStage_Initial match;

    /// <summary>
    /// Список игроков
    /// </summary>
    private readonly List<Player> players;

    /// <summary>
    /// Конструктор
    /// </summary>
    public HeroesCircleStage(MatchStage_Initial parent, List<Player> players)
    {
        match = parent;
        this.players = players;
    }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        //запускаем таймер
        UtilsManager.StartRoutine(StageTimer());
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
        List<Player> AIPlayers = new List<Player>();
        //выбираем в него всех AI игроков
        foreach (var item in players)
        {
            if (item is AIPlayer)
            {
                AIPlayers.Add(item);
            }
        }

        //раздаем всем AI по герою
        foreach (var item in AIPlayers)
        {
            //делаем паузу
            float pause = Random.Range(0f, 3f);
            yield return new WaitForSeconds(pause);
            //отдаем случайного героя AI и отключаем его
            item.SelectedHero = GameObject.FindObjectOfType<Hero>();
            item.SelectedHero.gameObject.SetActive(false);
        }

        //проверяем, все ли герои розданы
        if (AllHeroesDistributed())
        {
            match.ChangeStage();
        }
    }

    /// <summary>
    /// Проверяет все ли герои розданы
    /// </summary>
    private bool AllHeroesDistributed()
    {
        foreach (var item in players)
        {
            if (item.SelectedHero == null)
            {
                return false;
            }
        }
        return true;
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
        if (AllHeroesDistributed())
        {
            match.ChangeStage();
        }
        else
        {
            ForcedHeroesDistribution();
        }
    }

    /// <summary>
    /// Насильно распихивает случайных героев игрокам, не выбравшим себе героя 
    /// </summary>
    private void ForcedHeroesDistribution()
    {
        foreach (var item in players)
        {
            if (item.SelectedHero == null)
            {
                //отдаем случайного героя отключаем его
                item.SelectedHero = GameObject.FindObjectOfType<Hero>();
                item.SelectedHero.gameObject.SetActive(false);
            }
        }
        match.ChangeStage();
    }

    /// <summary>
    /// Создает круг героев и размещает его в сцене
    /// </summary>
    private HeroesCircle SpawnHeroesCircle()
    {
        GameObject heroesCircleGO = UtilsManager.Spawn(Resources.Load("TestObjects/HeroesCircle") as GameObject);
        return heroesCircleGO.GetComponent<HeroesCircle>();
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    public override void Initialize()
    {
        StageName = "Круг героев";
        //создаем и получаем круг героев
        HeroesCircle = SpawnHeroesCircle();
        //создаем героев
        HeroesCircle.CreateHeroes();
    }


    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public override void Exit()
    {
        //удаляем двух оставшихся героев с круга
        foreach (var item in GameObject.FindObjectsOfType<Hero>())
        {
            item.SelfDestruction();
        }
        //отключаем круг
        HeroesCircle.gameObject.SetActive(false);
        base.Exit();
    }
}
