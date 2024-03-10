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
    public Image image;
    public Color selectedColor, notSelectedColor;

    public bool IsEmpty => GetComponentInChildren<InventoryItem>() == null;

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
}