using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "Item", menuName = "BGS/Items/Blank", order = 1)]
public class Item : ScriptableObject
{
    public int value;
    public GameObject itemObject;
    public Sprite itemSprite;
}