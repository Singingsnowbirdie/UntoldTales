using System.Collections.Generic;
using UnityEngine;

public class HeroesMarketUI : MonoBehaviour
{
    /// <summary>
    /// Карточки героев
    /// </summary>
    PriceTag[] tags;

    private void OnEnable()
    {
        tags = GetComponentsInChildren<PriceTag>();
    }

    /// <summary>
    /// Показывает новый набор героев
    /// </summary>
    private void ShowNewHeroes(List<Hero> heroes)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            tags[i].ShowHeroInfo(heroes[i]);
        }
    }

    /// <summary>
    /// Кнопка "Обновить"
    /// </summary>
    public void RefreshBttn()
    {
        EventManager.OnBttnPressedEventInvoke(Bttn.RefreshMarketBttn);
    }
}
