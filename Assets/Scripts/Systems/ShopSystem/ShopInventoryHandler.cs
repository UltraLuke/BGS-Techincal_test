using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopInventoryHandler : MonoBehaviour
{
    //This script manages the selling list
    //It is similar to the ShopListHandler, but instead of getting the items from a pre-defined list, it takes from the player inventory.
    //It was NOT taken from tutorials
    
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private Transform itemList;
    [SerializeField] private GameObject noItemsText;

    private IShopCustomer _shopCustomer;
    private List<ShopItem> _shopItems;
    
    private void OnEnable()
    {
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

    //Everytime I show this screen, I perform a refresh of the list
    public void RefreshItems()
    {
        if (_shopCustomer != null)
        {
            DestroyOldItems();
            Initialise(_shopCustomer);
            CheckIfEmpty();
        }
        
    }

    //Destroys the current items in list before getting the new ones.
    private void DestroyOldItems()
    {
        if (_shopItems == null) return;
        
        foreach (var item in _shopItems)
            Destroy(item.gameObject);
        
        _shopItems = null;
    }
}