using System.Collections.Generic;
using UnityEngine;

public class TemporaryStoragePanel : MonoBehaviour
{
    /// <summary>
    /// Отряд
    /// </summary>
    SquadController squad;

    /// <summary>
    /// Карточки героев
    /// </summary>
    List<HeroMarketCard> heroCards;

    void Awake()
    {
        EventManager.OnSomethingChanged += SomethingChanged;
    }

    /// <summary>
    /// Количество чего-то поменялось
    /// </summary>
    private void SomethingChanged(int arg1, Changeable value)
    {
        //если изменилось количество героев в хранилище
        if (value == Changeable.Storage)
        {
            CheckStatus();
        }
    }

    internal void CheckStatus()
    {
        //если отряд не найден, находим
        if (squad == null) squad = FindObjectOfType<Scene>().GetController<SquadController>();

        //если карточки не найдены, находим
        if (heroCards == null)
        {
            heroCards = new List<HeroMarketCard>();
            heroCards.AddRange(gameObject.GetComponentsInChildren<HeroMarketCard>());
        }

        //скрываем все карточки
        foreach (var item in heroCards)
        {
            item.gameObject.SetActive(false);
        }

        //заглядываем в хранилище
        List<Hero> heroesInTemp = squad.GetHeroesInTemporaryStorage();

        //для каждого героя во временном хранилище
        for (int i = 0; i < heroesInTemp.Count; i++)
        {
            //заполняем и показываем карточку
            heroCards[i].ShowHeroInfo(heroesInTemp[i]);
            heroCards[i].gameObject.SetActive(true);
        }
    }
}
