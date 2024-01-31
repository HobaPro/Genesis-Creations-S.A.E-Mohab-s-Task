using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketInventoryItemUI : MonoBehaviour
{
    public int ItemId { get; set; }

    [SerializeField] private Text _itemNameTxt;
    [SerializeField] private Text _itemPriceTxt;

    [SerializeField] private Button _buyBtn;
    // Start is called before the first frame update
    void Start()
    {
        _buyBtn.onClick.AddListener(BuyItem);
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

    public void BuyItem()
    {
        TradeManager.instance.BuyItem(ItemId);
    }
}
