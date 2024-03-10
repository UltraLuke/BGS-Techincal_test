using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopListHandler : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private Transform itemList;
    [SerializeField] private ShopItem shopItemPrefab;
    
    private void Start()
    {
        foreach (var item in items)
        {
            Instantiate(shopItemPrefab, itemList).InitialiseItem(item.itemSprite, item.title, item.buyValue);
        }
    }
}