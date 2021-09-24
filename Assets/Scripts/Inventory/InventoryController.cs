using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : Controller
{
    /// <summary>
    /// Инвентарь
    /// </summary>
    Inventory inventory;

    public override void Initialize()
    {
        base.Initialize();
        inventory = new Inventory();
    }


    private void OnDestroy()
    {
    }

    /// <summary>
    /// Добавляет монеты 
    /// </summary>
    public void AddCoins(int amount)
    {
        inventory.Coins += amount;
        EventManager.CoinsAmountChanged(inventory.Coins);
    }

    /// <summary>
    /// Отнимает монеты 
    /// </summary>
    public void SpendCoins(int amount)
    {
        inventory.Coins -= amount;
        EventManager.CoinsAmountChanged(inventory.Coins);
    }

}
