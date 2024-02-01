using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public void BuyItem(int itemId)
    {
        Item item = GetComponent<Inventory>().GetItem(itemId);

        if (!item)
        {
            UIManager.instance.AlertMessage("Item isn't exist in the market inventory", true);

            return;
        }

        if (GameManager.instance.player.GetComponent<Cash>().Amount < item.Price)
        {
            UIManager.instance.AlertMessage("You have not enough chash to buy this item.", true);

            return;
        }

        GameManager.instance.player.GetComponent<Cash>().Amount -= item.Price;

        GetComponent<Inventory>().RemoveItem(item);
        GameManager.instance.player.GetComponent<Inventory>().AddItem(item);
    }

    public void SellItem(int itemId)
    {
        Item item = GameManager.instance.player.GetComponent<Inventory>().GetItem(itemId);

        if (!item )
        {
            Debug.Log("Item isn't exist in your inventory");

            return;
        }

        GameManager.instance.player.GetComponent<Cash>().Amount += item.Price;
        GameManager.instance.player.GetComponent<Inventory>().RemoveItem(item);
        GetComponent<Inventory>().AddItem(item);
    }
}
