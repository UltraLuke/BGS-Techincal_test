using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI coinsText;

    public void InitialiseItem(Sprite sprite, string title, int value)
    {
        image.sprite = sprite;
        titleText.text = title;
        coinsText.text = value.ToString();
    }
}