using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TestBankHeroes 
{
    public static Dictionary<Collider, Hero> EnemiesOnAren = new Dictionary<Collider, Hero>();

    static TestBankHeroes()
    {
        Add_Heroes_To_Lists_Info();
    }

    public static void Add_Heroes_To_Lists_Info()
    {
        foreach (var item in GameObject.FindObjectsOfType<Hero>())
        {
            EnemiesOnAren.Add(item.GetComponent<Collider>(), item);
        }
    }
}
