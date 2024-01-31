using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketInventoryWindow : MonoBehaviour
{
    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _itemPrefab;

    private void OnEnable()
    {
        UpdateContent();

        // Add "UpdateContent" method as event listener, event listener will executed when "OnMarketInventoryChanged" triggered to update player inventory UI content.
        // This event will triggered when market inventory changed.
        MarketInventory.OnMarketInventoryChanged += UpdateContent;
    }

    private void OnDisable()
    {
        // Remove "UpdateContent" event listener, until it is not executed when "OnMarketInventoryChanged" triggered.
        MarketInventory.OnMarketInventoryChanged -= UpdateContent;
    }

    // This method will executed when "OnMarketInventoryChanged" triggered to update market inventory UI content.
    // This method will executed when market inventory changed.
    public void UpdateContent()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in GameManager.instance.market.GetComponent<Inventory>().inventory)
        {
            MarketInventoryItemUI itemUI = Instantiate(_itemPrefab, _content).GetComponent<MarketInventoryItemUI>();

            itemUI.ItemId = item.id;
            itemUI.SetItemName(item.name);
            itemUI.SetItemPrice(item.price);
        }
    }
}
