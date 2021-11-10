using System;
using UnityEngine;

//Живой игрок
public class RealPlayer : Player
{
    public RealPlayer(int id) : base(id) { }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    protected override void OnStageEnter(IStage stage)
    {
        base.OnStageEnter(stage);
        //Круг героев
        if (stage is HeroesCircleStage)
        {
            //подписываемся на выбор героя
            EventManager.OnHeroSelected += OnHeroSelected;
        }
        //Стадия планирования
        else if (stage is PlanningStage)
        {
            //сообщаем о приобретении героя (которого мы выбрали на круге)
            EventManager.OnHeroPurchasedEventInvoke(SelectedHeroName);
            //и забываем о нем
            SelectedHeroName = "";
        }
    }

    /// <summary>
    /// При клике на героя (на круге)
    /// </summary>
    /// <param name="obj"></param>
    private void OnHeroSelected(string heroName)
    {
        //запоминаем имя героя
        SelectedHeroName = heroName;
        //отписываемся
        EventManager.OnHeroSelected -= OnHeroSelected;
    }
}
