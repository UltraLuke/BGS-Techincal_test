using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryArea : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    private InventorySlot[] _slots;
    private int selectedSlot = -1;
    
    private void Start()
    {
        GetSlots();
        // ChangeSelectedSlot(0);
    }

    private void GetSlots()
    {
        if (_slots == null)
            _slots = GetComponentsInChildren<InventorySlot>();
    }

    public bool AddNewItem(Item item)
    {
        if (FindFirstEmptySlot(out var slot))
        {
            SpawnNewItem(item, slot);
            return true;
        }
        
        return false;
    }

    private void SpawnNewItem (Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void RemoveItem(Item item)
    {
        var itemSlot = _slots.Where(x => !x.IsEmpty)
                             .FirstOrDefault(x => x.ItemInSlot.item == item);
        
        if(itemSlot != null)
            itemSlot.RemoveItem();
    }

    public bool FindFirstEmptySlot(out InventorySlot slot)
    {
        slot = _slots.FirstOrDefault(x => x.IsEmpty);
        return slot != default;
    }

    public bool CheckSpace()
    {
        return _slots.Any(x => x.IsEmpty);
    }

    public Item[] GetItems()
    {
        GetSlots();
        
        return _slots.Where(x => !x.IsEmpty)
                     .Select(x => x.GetComponentInChildren<InventoryItem>())
                     .Select(x => x.item).ToArray();
    }
}
