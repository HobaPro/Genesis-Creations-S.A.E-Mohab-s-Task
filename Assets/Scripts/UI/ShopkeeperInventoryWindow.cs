using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInventoryWindow : MonoBehaviour
{
    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _itemPrefab;

    private void OnEnable()
    {
        UpdateContent();
        MarketInventory.OnMarketInventoryChanged += UpdateContent;
    }

    private void OnDisable()
    {
        MarketInventory.OnMarketInventoryChanged -= UpdateContent;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void UpdateContent()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in GameManager.instance.market.GetComponent<Inventory>().inventory)
        {
            ShopkeeperInventoryItemUI itemUI = Instantiate(_itemPrefab, _content).GetComponent<ShopkeeperInventoryItemUI>();

            itemUI.ItemId = item.id;
            itemUI.SetItemName(item.name);
            itemUI.SetItemPrice(item.price);
        }
    }
}
