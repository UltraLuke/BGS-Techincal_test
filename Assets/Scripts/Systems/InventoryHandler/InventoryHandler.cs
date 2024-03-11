using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviour
{
    //This script is the one that the player access
    //This script was NOT taken from tutorials.
    
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
        EventsManager.TriggerEvent("EV_PAUSE_GAME");
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        backpackIcon.SetActive(true);
        EventsManager.TriggerEvent("EV_RESUME_GAME");
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
