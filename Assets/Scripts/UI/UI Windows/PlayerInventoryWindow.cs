using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryWindow : MonoBehaviour
{
    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _itemPrefab;

    private void OnEnable()
    {
        UpdateContent();

        // Add "UpdateContent" method as event listener, event listener will executed when "OnPlayerInventoryChanged" triggered to update player inventory UI content.
        // This event will triggered when player inventory changed.
        PlayerInventory.OnPlayerInventoryChanged += UpdateContent;
    }

    private void OnDisable()
    {
        // Remove "UpdateContent" event listener, until it is not executed when "OnPlayerInventoryChanged" triggered.
        PlayerInventory.OnPlayerInventoryChanged -= UpdateContent;
    }

    // This method will executed when "OnPlayerInventoryChanged" triggered to update player inventory UI content.
    // This method will executed when player inventory changed.
    public void UpdateContent()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in GameManager.instance.player.GetComponent<Inventory>().inventory)
        {
            PlayerInventoryItemUI itemUI = Instantiate(_itemPrefab, _content).GetComponent<PlayerInventoryItemUI>();

            itemUI.ItemId = item.id;
            itemUI.SetItemName(item.Name);
            itemUI.SetItemPrice(item.Price);
        }
    }
}
