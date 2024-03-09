using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOutfitHandler : MonoBehaviour
{
    [SerializeField] private ItemOutfitBottom bottomOutfit;
    [SerializeField] private Transform bottomSpace;
    [SerializeField] private ItemOutfitTop topOutfit;
    [SerializeField] private Transform topSpace;
    [SerializeField] private ItemOutfitHair hairOutfit;
    [SerializeField] private Transform hairSpace;
    [SerializeField] private ItemOutfitHat hatOutfit;
    [SerializeField] private Transform hatSpace;

    //Declares variables to access outfits that could be altered by others
    private GameObject _currentHair;
    private GameObject _currentHat;
    private GameObject _currentTop;
    private GameObject _currentBottom;
    
    #region Outfit setters

    //Base setter
    private void SetOutfit<T>(T newOutfit, ref T currentOutfit, ref GameObject currentOutfitObject, Transform outfitSpace, Action onOutfitSet = null) where T : ItemOutfit
    {
        if (newOutfit != null && newOutfit.itemObject != null)
        {
            if (currentOutfitObject != null)
                Destroy(currentOutfitObject);

            currentOutfitObject = Instantiate(newOutfit.itemObject, outfitSpace);
            currentOutfit = newOutfit;
            
            onOutfitSet?.Invoke();
        }
    }
    
    //Sets bottom outfit
    public void SetOutfit(ItemOutfitBottom outfit)
    {
        // if (outfit != null && outfit.itemObject != null)
        // {
        //     if (_currentBottom != null)
        //         Destroy(_currentBottom);
        //     
        //     _currentBottom = Instantiate(outfit.itemObject, bottomSpace);
        //     bottomOutfit = outfit;
        // }

        SetOutfit(outfit, ref bottomOutfit, ref _currentBottom, bottomSpace);
    }

    //Sets top outfit
    public void SetOutfit(ItemOutfitTop outfit)
    {
        // if (outfit != null && outfit.itemObject != null)
        // {
        //     if(_currentTop != null)
        //         Destroy(_currentTop);
        //     
        //     _currentTop = Instantiate(outfit.itemObject, topSpace);
        //     topOutfit = outfit;
        // }
        
        SetOutfit(outfit, ref topOutfit, ref _currentTop, topSpace);
    }
    //Sets hair
    public void SetOutfit(ItemOutfitHair outfit)
    {
        // if (outfit != null && outfit.itemObject != null)
        // {
        //     //I destroy the old reference
        //     if (_currentHair != null)
        //         Destroy(_currentHair);
        //     
        //     _currentHair = Instantiate(outfit.itemObject, hairSpace);
        //     hairOutfit = outfit;
        //     
        //     //When I set a hair and there's hat that overrides hair, I disable the hat
        //     if (_currentHat != null && hatOutfit.OverridesHair)
        //         _currentHat.SetActive(false);
        // }
        
        SetOutfit(outfit, ref hairOutfit, ref _currentHair, hairSpace, () =>
        {
            //When I set a hair and there's hat that overrides hair, I disable the hat
            if (_currentHat != null && hatOutfit.OverridesHair)
                _currentHat.SetActive(false);
        });
    }
    
    //Sets hat
    public void SetOutfit(ItemOutfitHat outfit)
    {
        // if (outfit != null && outfit.itemObject != null)
        // {
        //     //I destroy the old reference
        //     if (_currentHat != null)
        //         Destroy(_currentHat);
        //     
        //     _currentHat = Instantiate(outfit.itemObject, hatSpace);
        //     hatOutfit = outfit;
        //     
        //     //Checks if the hat overrides the hair (in case the hat and the hair don't look good together)
        //     if (outfit.OverridesHair && _currentHair != null)
        //         _currentHair.SetActive(false);
        // }
        
        SetOutfit(outfit, ref hatOutfit, ref _currentHat, hatSpace, () =>
        {
            //Checks if the hat overrides the hair (in case the hat and the hair don't look good together)
            if (outfit.OverridesHair && _currentHair != null)
                _currentHair.SetActive(false);
        });
    }
    
    #endregion

    public void ClearOutfit(OutfitType type)
    {
        switch (type)
        {
            case OutfitType.Bottom:
                bottomOutfit = null;
                Destroy(_currentBottom);
                break;
            case OutfitType.Top:
                topOutfit = null;
                Destroy(_currentTop);
                break;
            case OutfitType.Hair:
                hairOutfit = null;
                Destroy(_currentHair);
                break;
            case OutfitType.Hat:
                hatOutfit = null;
                Destroy(_currentHat);
                break;
        }
    }
}
