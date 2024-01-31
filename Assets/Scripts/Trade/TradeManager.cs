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

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void BuyItem(int itemId)
    {
        Item item = GameManager.instance.market.GetComponent<Inventory>().GetItem(itemId);

        if (!item)
        {
            UIManager.instance.ErrorMessage("Item isn't exist in the market inventory");

            return;
        }

        if (GameManager.instance.player.GetComponent<Cash>().Amount < item.price)
        {
            UIManager.instance.ErrorMessage("You have not enough chash to buy this item.");

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
