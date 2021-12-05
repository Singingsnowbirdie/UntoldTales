using System.Collections.Generic;
using UnityEngine;

//Контроллер отряда героев

public class SquadController : IController
{
    //конструктор
    public SquadController()
    {
        squad = new Squad();
        merger = new Merger(squad);

        //подписываемся на события
        EventManager.OnHeroPurchased += DistributeHero;
        EventManager.OnStageExit += OnStageExit;
    }

    //Возвращает коллекцию героев из временного хранилища
    internal List<Hero> GetHeroesInTemporaryStorage()
    {
        return squad.temporaryStorage;
    }

    /// <summary>
    /// Отряд
    /// </summary>
    readonly Squad squad;

    /// <summary>
    /// Класс, производящий слияние (повышение ранга)
    /// </summary>
    readonly Merger merger;

    /// <summary>
    /// Сцена
    /// </summary>
    public static MatchScene Scene { get; internal set; }

    public void OnStart() { }

    /// <summary>
    /// Решает, что делать с купленным героем
    /// </summary>
    /// <param name="obj"></param>
    private void DistributeHero(int heroID)
    {
        //если у игрока есть еще два таких же героя
        if (squad.FindTheSameHeroes(heroID) >= 2) merger.MergeTwo(heroID);
        //если нет, добавляем героя в отряд
        else AddHero(heroID);
    }

    /// <summary>
    /// Определяет купленного героя в резерв или во временное хранилище
    /// </summary>
    void AddHero(int heroID)
    {
        //если есть место в резерве
        if (squad.heroesInReserve.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя в резерв
            AddToReserve(heroID);
        }
        //если герой не помещается в резерве, проверяем, есть ли место во временном хранилище
        else if (squad.temporaryStorage.Count < squad.maxHeroesInReserveAndTemp)
        {
            //добавляем героя во временное хранилище
            AddToTemporaryStorage(heroID);
        }
        else
        {
            //продаем героя по его "закупочной" стоимости
        }
    }

    /// <summary>
    /// Добавляет героя во временное хранилище
    /// </summary>
    /// <param name="hero"></param>
    private void AddToTemporaryStorage(int heroID)
    {
        //создаем нового героя
        Hero hero = new Hero(Scene.GetHeroInfo(heroID));
        //помещаем его в коллекцию
        squad.temporaryStorage.Add(hero);
        //оповещаем об изменении количества героев в хранилище
        EventManager.OnSomethingChangedEventInvoke(squad.temporaryStorage.Count, Changeable.Storage);
    }

    /// <summary>
    /// Добавляет героя в резерв
    /// </summary>
    private void AddToReserve(int heroID)
    {
        //создаем нового героя
        Hero hero = new Hero(Scene.GetHeroInfo(heroID));
        //помещаем его в коллекцию
        squad.heroesInReserve.Add(hero);
        //оповещаем поле о необходимости заспавнить его
        EventManager.OnHeroReadyToSpawnEventInvoke(hero);
        //оповещаем об изменении количества героев в резерве
        EventManager.OnSomethingChangedEventInvoke(squad.heroesInReserve.Count, Changeable.Reserve);
    }

    /// <summary>
    /// Возвращает из бд героя по имени
    /// </summary>
    /// <returns></returns>
    private GameObject SelectHeroFromDB(string heroName)
    {
        Object[] heroes = Resources.LoadAll("TestObjects/Heroes");
        foreach (var item in heroes)
        {
            if ((item as GameObject).GetComponent<Hero>().Info.Name == heroName)
            {
                return item as GameObject;
            }
        }
        return null;
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    private void OnStageExit(IStage stage)
    {
        //при выходе из стадии планирования
        if (stage is PlanningStage)
        {
            TransferHeroesToBattle();
        }
    }

    /// <summary>
    /// Переносит всех героев из коллекции "на поле" в коллекцию "в бою"
    /// </summary>
    private void TransferHeroesToBattle()
    {
        foreach (var item in squad.heroesOnTheField)
        {
            squad.AddHeroToList(item, squad.heroesInBattle);
        }
        squad.heroesInBattle.Clear();
    }

    /// <summary>
    /// Изменяет максимальное количество героев на поле
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeMaxHeroesAmount(int experience, int leadership)
    {
        squad.MaxHeroesOnTheFieldAmount = leadership;
    }
    public void OnExit()
    {
        EventManager.OnHeroPurchased -= DistributeHero;
        EventManager.OnStageExit -= OnStageExit;
    }
}
