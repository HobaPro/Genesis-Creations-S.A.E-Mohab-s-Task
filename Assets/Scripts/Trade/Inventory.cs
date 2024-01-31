using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public List<Item> inventory { get; private set; } = new List<Item>();

    public void AddItem(Item item)
    {
        inventory.Add(item);

        OnItemAdded(item);
    }

    public Item GetItem(int id)
    {
        int index = inventory.FindIndex(i => i.id == id);

        if (index >= 0) return inventory[index];
        else return null;
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);

        OnItemRemoved(item);
    }

    public abstract void OnItemAdded(Item item);
    public abstract void OnItemRemoved(Item item);
}
