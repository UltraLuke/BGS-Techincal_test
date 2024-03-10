using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        FindObjectOfType<CoinsHandler>().AddOnCoinChangedCallback(OnChangeCoins);
    }

    private void OnChangeCoins(int coins)
    {
        coinText.text = coins.ToString();
    }
}
