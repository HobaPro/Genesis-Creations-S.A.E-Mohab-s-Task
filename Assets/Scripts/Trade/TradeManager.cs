using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    public static TradeManager instance { get; private set; }

    private void Awake()
    {
        // Intialize Singleton
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    public void BuyItem(int itemId)
    {
        Item item = GameManager.instance.market.GetComponent<Inventory>().GetItem(itemId);

        if (!item)
        {
            UIManager.instance.AlertMessage("Item isn't exist in the market inventory", true);

            return;
        }

        if (GameManager.instance.player.GetComponent<Cash>().Amount < item.price)
        {
            UIManager.instance.AlertMessage("You have not enough chash to buy this item.", true);

            return;
        }

        GameManager.instance.player.GetComponent<Cash>().Amount -= item.price;
        GameManager.instance.market.GetComponent<Inventory>().RemoveItem(item);
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

        GameManager.instance.player.GetComponent<Cash>().Amount += item.price;
        GameManager.instance.player.GetComponent<Inventory>().RemoveItem(item);
        GameManager.instance.market.GetComponent<Inventory>().AddItem(item);
    }
}
