using System;
using System.Collections.Generic;
using System.Linq;
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
        // CheckIfEmpty();
        RefreshItems();
    }

    private void OnDisable()
    {
        DestroyOldItems();
    }

    private void CheckIfEmpty()
    {
        if (_shopItems == null || _shopItems.Count == 0)
            noItemsText.SetActive(true);
        else
            noItemsText.SetActive(false);
    }

    public void Initialise(IShopCustomer customer)
    {
        // DestroyOldItems();
        
        _shopCustomer = customer;

        _shopItems ??= new List<ShopItem>();
        
        foreach (var item in _shopCustomer.GetCustomerInventory())
        {
            var shopItem = Instantiate(shopItemPrefab, itemList);
            shopItem.InitialiseItem(item, item.itemSprite, item.title, item.sellValue, it =>
            {
                _shopCustomer.SellItem(item);
                var shopIt = _shopItems.FirstOrDefault(shopIt => shopIt.GetItem == it);
                _shopItems.Remove(shopIt);
                
                if(shopIt != null)
                    shopIt.gameObject.SetActive(false);
                
                CheckIfEmpty();
            });
            _shopItems.Add(shopItem);
        }
    }

    public void RefreshItems()
    {
        if (_shopCustomer != null)
        {
            DestroyOldItems();
            Initialise(_shopCustomer);
            CheckIfEmpty();
        }
        
    }

    private void DestroyOldItems()
    {
        if (_shopItems == null) return;
        
        foreach (var item in _shopItems)
            Destroy(item.gameObject);
        
        _shopItems = null;
    }
}