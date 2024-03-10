using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShopListHandler shopList;
    [SerializeField] private ShopInventoryHandler shopInventory;

    private IShopCustomer _customer;

    private bool TryBuyItem(Item item)
    {
        if (_customer.CheckIfEnoughSpaceInInventory())
        {
            if (_customer.TrySpendGoldAmount(item.buyValue))
            {
                _customer.BoughtItem(item);
                return true;
            }
            else
            {
                Debug.Log("Not enough coins");
                return false;
            }
        }
        else
        {
            Debug.Log("Not enough space");
            return false;
        }
    }
    
    public void Show(IShopCustomer customer)
    {
        _customer = customer;
        gameObject.SetActive(true);
        shopList.Initialise(TryBuyItem);
        shopInventory.Initialise(customer);
    }

    public void Hide()
    {
        _customer = null;
        shopList.gameObject.SetActive(true);
        shopInventory.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}