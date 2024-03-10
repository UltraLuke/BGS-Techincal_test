using System;
using UnityEngine;

public class CoinsHandler : MonoBehaviour, ICoinsHolder
{
    [SerializeField] private int coins;
    private Action<int> _onChangeCoins;

    public void SpendCoins(int qty)
    {
        coins -= qty;
        _onChangeCoins?.Invoke(coins);
    }

    public void EarnCoins(int qty)
    {
        coins += qty;
        _onChangeCoins?.Invoke(coins);
    }
    
    public int GetCoinsAmount() => coins;

    public void AddOnCoinChangedCallback(Action<int> action)
    {
        _onChangeCoins += action;
    }
}