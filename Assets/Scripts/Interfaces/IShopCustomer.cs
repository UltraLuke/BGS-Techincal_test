using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(Item item);
    bool TrySpendGoldAmount(int spendGoldAmount);
    bool CheckIfEnoughSpaceInInventory();
    Item[] GetCustomerInventory();
    void SellItem(Item item);
}
