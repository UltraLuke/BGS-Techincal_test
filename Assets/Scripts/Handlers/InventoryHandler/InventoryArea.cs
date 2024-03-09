using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryArea : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    private InventorySlot[] _slots;

    private void Start()
    {
        GetSlots();
    }

    public void GetSlots()
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

    public void ReplaceItem(Item newItem, InventorySlot slot)
    {
        slot.AddOrReplace(newItem);
    }

    public Item RemoveItem(InventorySlot slot)
    {
        return slot.Remove();
    }

    private bool FindFirstEmptySlot(out InventorySlot slot)
    {
        slot = _slots.FirstOrDefault(x => x.IsEmpty);
        return slot != default;
    }
}
