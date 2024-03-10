using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopListHandler : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private Transform itemList;
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private GameObject noItemsText;

    private bool _alreadyInitialised;
    private List<ShopItem> _shopItems;

    private void OnEnable()
    {
        CheckIfEmpty();
    }

    private void CheckIfEmpty()
    {
        if (_shopItems == null || _shopItems.Count == 0)
            noItemsText.SetActive(true);
        else
            noItemsText.SetActive(false);
    }

    public void Initialise(Func<Item,bool> onClickButtonEvent)
    {
        if (_alreadyInitialised) return;
            
        _shopItems ??= new List<ShopItem>();
        
        foreach (var item in items)
        {
            var shopItem = Instantiate(shopItemPrefab, itemList);
            shopItem.InitialiseItem(item, item.itemSprite, item.title, item.buyValue, x =>
            {
                if (onClickButtonEvent(x))
                {
                    var shopIt = _shopItems.FirstOrDefault(shopIt => shopIt.GetItem == x);
                    items.Remove(x);
                    _shopItems.Remove(shopIt);
                    
                    if(shopIt != null)
                        shopIt.gameObject.SetActive(false);

                    CheckIfEmpty();
                }
            });
            _shopItems.Add(shopItem);
        }

        CheckIfEmpty();

        _alreadyInitialised = true;
    }
}