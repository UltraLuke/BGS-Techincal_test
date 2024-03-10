using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private InventoryArea _inventoryArea;
    [SerializeField] private Item[] startingItems;
    [SerializeField] private GameObject backpackIcon;

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
        backpackIcon.SetActive(false);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        backpackIcon.SetActive(true);
    }

    public bool AddItem(Item item)
    {
        return _inventoryArea.AddNewItem(item);
    }
    
    public void RemoveItem(Item item)
    {
        _inventoryArea.RemoveItem(item);
    }

    public bool CheckAvailableSpace()
    {
        return _inventoryArea.CheckSpace();
    }

}
