using System;
using UnityEngine;

public class Player
{
    public Player(int id)
    {
        ID = id;
        //подписываемся на вход игры  в состояние
        EventManager.OnStageEnter += OnStageEnter;
        //подписываемся на выход игры из состояния
        EventManager.OnStageExit += OnStageExit;
    }

    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Герой, выбранный на круге героев
    /// </summary>
    public Hero SelectedHero { get; set; }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    protected virtual void OnStageEnter(string stage)
    {
        //Круг героев
        if (stage == "Круг героев")
        {
            //подписываемся на выбор героя
            EventManager.OnHeroPointed += OnHeroPointed;
        }
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    protected virtual void OnStageExit(string stage)
    {

    }

    /// <summary>
    /// При клике на героя
    /// </summary>
    /// <param name="obj"></param>
    private void OnHeroPointed(Hero hero)
    {
        //запоминаем героя
        SelectedHero = hero;
        //отключаем его
        SelectedHero.gameObject.SetActive(false);
        //отписываемся
        EventManager.OnHeroPointed -= OnHeroPointed;
    }
}
