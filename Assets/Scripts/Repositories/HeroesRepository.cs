using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesRepository : Repository
{
    /// <summary>
    /// Все герои
    /// </summary>
    public List<Hero> Heroes;

    internal override void OnCreate()
    {
        //создаем список
        Heroes = new List<Hero>();
    }
    public override void Initialize()
    {
        //получаем массив инфо всех существующих героев
        var allHeroInfos = Resources.LoadAll<HeroInfo>("");
        //для каждого создаем своего героя, и помещаем его в массив всех героев
        foreach (var item in allHeroInfos)
        {
            //если есть ульта
            if (item.HasUltimateAbility == true) Heroes.Add(new UltimateHero(item));
            //если нет ульты
            else Heroes.Add(new PassiveAbilityHero(item));
        }
    }
    internal override void OnStart() { }
    public override void Save() { }

}
