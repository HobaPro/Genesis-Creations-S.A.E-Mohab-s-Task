using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketInventory : Inventory
{
    public static event Action OnMarketInventoryChanged;

    public override void OnItemAdded(Item item)
    {
        OnMarketInventoryChanged?.Invoke();
    }

    public override void OnItemRemoved(Item item)
    {
        OnMarketInventoryChanged?.Invoke();
    }
}
