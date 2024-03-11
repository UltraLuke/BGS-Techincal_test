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
    //This script was mainly taken form tutorials from internet.
    //It has been extended with inheritance to provide additional functionality to outfit slots (see InventoryOutfitSlot.cs)
    
    public Image image;
    public Color selectedColor, notSelectedColor;

    public bool IsEmpty => GetComponentInChildren<InventoryItem>() == null;
    public InventoryItem ItemInSlot => GetComponentInChildren<InventoryItem>(); 

    protected virtual void Awake()
    {
        Deselect();
    }

    public void Select() => image.color = selectedColor;
    public void Deselect() => image.color = notSelectedColor;

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if(eventData.pointerDrag.TryGetComponent<InventoryItem>(out var inventoryItem))
                inventoryItem.parentAfterDrag = transform;
        }
    }

    //I added this method when an item from the inventory is being removed
    public void RemoveItem()
    { 
        Destroy(ItemInSlot.gameObject);
    }
}