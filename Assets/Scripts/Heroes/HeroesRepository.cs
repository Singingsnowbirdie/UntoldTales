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
        //помещаем в список героев (образцы)
        Heroes.Add(new PassiveAbilityHeroExample());
        Heroes.Add(new UltimateHeroExample());
    }
    internal override void OnStart() { }
    public override void Save() { }

}
