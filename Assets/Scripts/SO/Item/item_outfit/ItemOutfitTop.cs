using UnityEngine;

[CreateAssetMenu(menuName = "BGS/Outfit/Top", fileName = "Top", order = 2)]
public class ItemOutfitTop : ItemOutfit
{
    [SerializeField] private bool overridesBottom;

    public ItemOutfitTop(bool overridesBottom)
    {
        this.overridesBottom = overridesBottom;
    }

    public bool OverridesBottom => overridesBottom;
}