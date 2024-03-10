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

    private void OnEnable()
    {
        if (items == null || items.Count == 0)
            noItemsText.SetActive(true);
        else
            noItemsText.SetActive(false);
    }

    public void Initialise(Action<Item> onClickButtonEvent)
    {
        foreach (var item in items)
        {
            Instantiate(shopItemPrefab, itemList).InitialiseItem(item, item.itemSprite, item.title, item.buyValue, x =>
            {
                onClickButtonEvent?.Invoke(x);
                items.Remove(x);
            });
        }

    }
}