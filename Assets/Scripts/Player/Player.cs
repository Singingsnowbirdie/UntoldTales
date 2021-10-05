using System;
using UnityEngine;

public class Player
{
    public Player(int id)
    {
        ID = id;
        //подписываемся на вход в состояние
        EventManager.OnStageEnter += OnStageEnter;
        //подписываемся на выход из состояния
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
        if (stage == "HeroesCircleStage")
        {
            //подписываемся на выбор героя
            EventManager.OnHeroSelected += OnHeroSelected;
        }
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    /// <param name="obj"></param>
    protected virtual void OnStageExit(string stage)
    {
        //Круг героев
        if (stage == "HeroesCircleStage")
        {
            //отписываемся от выбора героя
            EventManager.OnHeroSelected -= OnHeroSelected;
        }
    }

    /// <summary>
    /// Игрок выбрал себе героя на Круге
    /// </summary>
    private void OnHeroSelected(Hero hero, int heroID)
    {
        //проверяем, пришло сообщение от нашего игрока, или от другого
        if (heroID == ID)
        {
            SelectedHero = hero;
        }
    }
}
