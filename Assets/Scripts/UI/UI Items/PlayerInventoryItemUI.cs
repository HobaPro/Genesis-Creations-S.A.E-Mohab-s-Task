using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryItemUI : MonoBehaviour
{
    public int ItemId {  get; set; }

    [SerializeField] private Text _itemNameTxt;
    [SerializeField] private Text _itemPriceTxt;

    [SerializeField] private Button _sellBtn;
    // Start is called before the first frame update
    void Start()
    {
        _sellBtn.onClick.AddListener(SellItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItemName(string itemName)
    {
        _itemNameTxt.text = itemName;
    }

    public void SetItemPrice(float itemPrice)
    {
        _itemPriceTxt.text = $"{itemPrice}$";
    }

    public void SellItem()
    {
        GameManager.instance.ActiveMarket.SellItem(ItemId);
    }
}
