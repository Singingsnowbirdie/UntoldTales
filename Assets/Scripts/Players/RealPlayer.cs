using System;
using UnityEngine;

//Живой игрок
public class RealPlayer : Player
{
    public RealPlayer(int id) : base(id) { }

    /// <summary>
    /// При входе в состояние
    /// </summary>
    protected override void OnStageEnter(string stage)
    {
        base.OnStageEnter(stage);
        //Круг героев
        if (stage == "Круг героев")
        {
            //подписываемся на выбор героя
            EventManager.OnHeroSelected += OnHeroSelected;
        }
    }

    /// <summary>
    /// При клике на героя
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
