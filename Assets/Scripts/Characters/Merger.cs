using System;
using System.Collections.Generic;
using UnityEngine;

//класс, производящий слияние одинаковых героев, с повышением ранга

public class Merger : MonoBehaviour
{
    //отряд
    private Squad squad;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Merger(Squad squad)
    {
        this.squad = squad;
    }

    /// <summary>
    /// Объединяет двух одинаковых героев (после покупки третьего такого же)
    /// </summary>
    internal void MergeTwo(int heroID)
    {
        //двух героев ищем, один "в уме" (помним, что он был куплен (получен), но его экземпляр не был создан)

        //сначала ищем героев на поле и в резерве
        List<Hero> heroes = GetHeroesToMerge(heroID);

        //если найдены оба героя
        if (heroes.Count == 2)
        {
            //выбираем героя, которого будем улучшать
            int heroToRaise = HeroToRaise(heroes);

            //раздеваем обоих героев
            List<Item> temporaryBackpack = Undress(heroes);

            //улучшаем нужного, второго удаляем
            for (int i = 0; i < heroes.Count; i++)
            {
                if (i == heroToRaise) heroes[i].RaiseAndEquip(temporaryBackpack);
                else squad.RemoveHero(heroes[i]);
            }
        }
    }

    /// <summary>
    /// Раздевает обоих героев, помещая их вещи во временный рюкзак
    /// </summary>
    private List<Item> Undress(List<Hero> heroes)
    {
        List<Item> backpack = new List<Item>();
        //снимаем с героев все, что на них надето, и складываем в "рюкзак"
        foreach (var item in heroes)
        {
            backpack.AddRange(item.Inventory.Undress());
        }
        return backpack;
    }

    /// <summary>
    /// Собираем героев для мерджа
    /// </summary>
    private List<Hero> GetHeroesToMerge(int heroID)
    {
        //создаем пустую коллекцию
        List<Hero> heroesToMerge = new List<Hero>();

        //сначала ищем на поле
        foreach (var item in squad.heroesOnTheField)
        {
            if (item.Info.ID == heroID)
            {
                heroesToMerge.Add(item);
                if (heroesToMerge.Count == 2)
                {
                    return heroesToMerge;
                }
            }
        }

        //теперь ищем в резерве
        foreach (var item in squad.heroesInReserve)
        {
            if (item.Info.ID == heroID)
            {
                heroesToMerge.Add(item);
                if (heroesToMerge.Count == 2)
                {
                    return heroesToMerge;
                }
            }
        }

        return heroesToMerge;
    }

    /// <summary>
    /// Определяет наиболее актуального героя для улучшения
    /// </summary>
    /// <returns></returns>
    private int HeroToRaise(List<Hero> heroes)
    {
        //если стоимость экипировки второго героя больше, то улучшать будем его
        if (heroes[1].Inventory.EquipmentСost > heroes[0].Inventory.EquipmentСost) return 1;
        //во всех остальных случаях, улучшать будем первого
        else return 0;
    }

}
