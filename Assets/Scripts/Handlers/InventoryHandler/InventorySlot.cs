using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // [SerializeField] private Item startingItem;
    // [SerializeField] private Image image;

    public bool IsEmpty => GetComponentInChildren<InventoryItem>() == null;

    private void Start()
    {
        // _item = startingItem;
    }

    public void AddOrReplace(Item i)
    {
        // _item = i;
    }

    public Item Remove()
    {
        // Item removedItem = _item;
        // _item = null;
        // return removedItem;
        return default;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
