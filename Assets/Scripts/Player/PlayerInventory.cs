using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static event Action OnPlayerInventoryChanged;

    // This virtual method invoked when any item added into player inventory
    public override void OnItemAdded(Item item)
    {
        // Trigger an OnPlayerInventoryChanged event when item added into the player inventory
        OnPlayerInventoryChanged?.Invoke();
    }

    // This virtual method invoked when any item removed from player inventory
    public override void OnItemRemoved(Item item)
    {
        // Trigger an OnPlayerInventoryChanged event when item removed from the player inventory
        OnPlayerInventoryChanged?.Invoke();
    }
}
