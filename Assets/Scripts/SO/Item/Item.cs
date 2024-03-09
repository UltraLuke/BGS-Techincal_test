using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic", menuName = "BGS/Basic", order = 1)]
public class Item : ScriptableObject
{
    public GameObject itemObject;
    public Sprite itemSprite;
}