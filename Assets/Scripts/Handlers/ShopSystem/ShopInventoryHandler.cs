using UnityEngine;

public class ShopInventoryHandler : MonoBehaviour
{
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private Transform itemList;
    private IShopCustomer _shopCustomer;

    private void OnEnable()
    {
        if (_shopCustomer == null) return;
        
        foreach (var item in _shopCustomer.GetCustomerInventory())
            Instantiate(shopItemPrefab, itemList).InitialiseItem(item.itemSprite, item.title, item.sellValue);
    }
}