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
}
