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

        PlayerInventory.OnPlayerInventoryChanged += UpdateContent;
    }

    private void OnDisable()
    {
        PlayerInventory.OnPlayerInventoryChanged -= UpdateContent;
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

        foreach (Item item in GameManager.instance.player.GetComponent<Inventory>().inventory)
        {
            PlayerInventoryItemUI itemUI = Instantiate(_itemPrefab, _content).GetComponent<PlayerInventoryItemUI>();

            itemUI.ItemId = item.id;
            itemUI.SetItemName(item.name);
            itemUI.SetItemPrice(item.price);
        }
    }
}
