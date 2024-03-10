using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    public InventoryArea InventoryArea;
    public Item[] itemsToAdd;
    public GameObject warningMessage;
    public void AddItem(int id)
    {
        if (!InventoryArea.AddNewItem(itemsToAdd[id]))
        {
            warningMessage.SetActive(true);
        }
    }
}
