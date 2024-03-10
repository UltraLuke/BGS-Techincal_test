using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private InventoryArea _inventoryArea;
    [SerializeField] private Item[] startingItems;

    private void Start()
    {
        if (startingItems != null)
        {
            foreach (var item in startingItems)
            {
                _inventoryArea.AddNewItem(item);
            }
        }
    }

    public Item[] GetItems() => _inventoryArea.GetItems();

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool AddItem(Item item)
    {
        return _inventoryArea.AddNewItem(item);
    }

    public bool CheckAvailableSpace()
    {
        return _inventoryArea.CheckSpace();
    }
}
