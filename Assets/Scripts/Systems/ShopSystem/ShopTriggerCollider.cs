using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IShopCustomer>(out var customer))
        {
            _shopManager.Show(customer);
        }
    }
}
