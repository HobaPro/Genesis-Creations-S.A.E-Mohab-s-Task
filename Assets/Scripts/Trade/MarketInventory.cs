using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketInventory : Inventory
{
    public static event Action OnMarketInventoryChanged;

    // This virtual method invoked when any item added into market inventory
    public override void OnItemAdded(Item item)
    {
        // Trigger an OnPlayerInventoryChanged event when item added into the market inventory
        OnMarketInventoryChanged?.Invoke();
    }

    // This virtual method invoked when any item removed from market inventory
    public override void OnItemRemoved(Item item)
    {
        // Trigger an OnPlayerInventoryChanged event when item removed from the market inventory
        OnMarketInventoryChanged?.Invoke();
    }
}
