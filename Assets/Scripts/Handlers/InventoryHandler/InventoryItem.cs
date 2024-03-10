using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    [Header("UI")]
    [SerializeField] private Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    private InventorySlot _currentSlot;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.itemSprite;
        _currentSlot = GetComponentInParent<InventorySlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        _currentSlot = GetComponentInParent<InventorySlot>();
    }
    
    public void Select()
    {
        if(_currentSlot != null)
            _currentSlot.Select();
    }

    public void Deselect()
    {
        if(_currentSlot != null)
            _currentSlot.Deselect();
    }
}
