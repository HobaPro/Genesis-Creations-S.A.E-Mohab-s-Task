using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _inventory;
    public List<Item> inventory
    {
        get => _inventory;
        set { }
    }

    // This method to add an item into inventory list above
    public void AddItem(Item item)
    {
        _inventory.Add(item);

        // Invoke the abstract method with item added to inventory list as parameter.
        OnItemAdded(item);
    }

    // This method returns item if this item is exists, and returns null if item isn't exists.
    public Item GetItem(int id)
    {
        int index = _inventory.FindIndex(i => i.id == id);

        if (index >= 0) return _inventory[index];
        else return null;
    }

    // This method to remove an item from inventory list above
    public void RemoveItem(Item item)
    {
        _inventory.Remove(item);

        // Invoke the abstract method with item added to inventory list as parameter.
        OnItemRemoved(item);
    }

    public abstract void OnItemAdded(Item item);
    public abstract void OnItemRemoved(Item item);
}
