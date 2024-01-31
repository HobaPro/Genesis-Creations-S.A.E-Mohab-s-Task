using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static event Action OnPlayerInventoryChanged;

    public override void OnItemAdded(Item item)
    {
        OnPlayerInventoryChanged?.Invoke();
    }

    public override void OnItemRemoved(Item item)
    {
        OnPlayerInventoryChanged?.Invoke();
    }
}
