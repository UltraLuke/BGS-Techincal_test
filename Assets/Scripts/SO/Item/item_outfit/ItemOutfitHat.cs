using UnityEngine;

[CreateAssetMenu(menuName = "BGS/Outfit/Hat", fileName = "Hat", order = 0)]
public class ItemOutfitHat : ItemOutfit
{
    [SerializeField] private bool overridesHair;

    public ItemOutfitHat(bool overridesHair)
    {
        this.overridesHair = overridesHair;
    }

    public bool OverridesHair => overridesHair;
}