using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShopListHandler shopList;
    [SerializeField] private ShopInventoryHandler shopInventory;

    private IShopCustomer _customer;

    private void TryBuyItem(Item item)
    {
        _customer.BoughtItem(item);
    }
    
    public void Show(IShopCustomer customer)
    {
        _customer = customer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        _customer = null;
        shopList.gameObject.SetActive(true);
        shopInventory.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}