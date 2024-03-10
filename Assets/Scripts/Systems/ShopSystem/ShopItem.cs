using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Button _button;

    public void InitialiseItem(Item item, Sprite sprite, string title, int value, Action<Item> onClickEvent)
    {
        image.sprite = sprite;
        titleText.text = title;
        coinsText.text = value.ToString();
        _button.onClick.AddListener(() => onClickEvent?.Invoke(item));
    }
}