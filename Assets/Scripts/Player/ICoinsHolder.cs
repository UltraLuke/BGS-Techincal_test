using System;

public interface ICoinsHolder
{
    void AddOnCoinChangedCallback(Action<int> action) { }
}