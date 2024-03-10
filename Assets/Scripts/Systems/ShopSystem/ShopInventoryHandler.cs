using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryHandler : MonoBehaviour
{
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private Transform itemList;
    [SerializeField] private GameObject noItemsText;

    private IShopCustomer _shopCustomer;
    private List<ShopItem> _shopItems;

    private void OnEnable()
    {
        if (_shopItems == null || _shopItems.Count == 0)
            noItemsText.SetActive(true);
        else
            noItemsText.SetActive(false);
    }

    public void Initialise(IShopCustomer customer)
    {
        DestroyOldItems();
        
        _shopCustomer = customer;

        _shopItems ??= new List<ShopItem>();
        
        foreach (var item in _shopCustomer.GetCustomerInventory())
        {
            var shopItem = Instantiate(shopItemPrefab, itemList);
            
            //ADD SELLING EVENT
            shopItem.InitialiseItem(item, item.itemSprite, item.title, item.sellValue, item1 => {});
            _shopItems.Add(shopItem);
        }
        
        noItemsText.SetActive(noItemsText);

    }

    private void DestroyOldItems()
    {
        if (_shopItems == null) return;
        
        foreach (var item in _shopItems)
            Destroy(item);
        
        _shopItems = null;
    }
}