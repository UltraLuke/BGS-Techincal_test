using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OutfitSelectionHandler : MonoBehaviour
{
    [SerializeField] private CharacterOutfitHandler outfitHandler;
    [Space()]
    [SerializeField] private List<ItemOutfitBottom> bottomOutfits;
    [SerializeField] private List<ItemOutfitTop> topOutfits;
    [SerializeField] private List<ItemOutfitHair> hairOutfits;
    [SerializeField] private List<ItemOutfitHat> hatOutfits;

    private ItemOutfitBottom _currentBottom;
    private int _bottomIndex;
    private ItemOutfitTop _currentTop;
    private int _topIndex;
    private ItemOutfitHair _currentHair;
    private int _hairIndex;
    private ItemOutfitHat _currentHat;
    private int _hatIndex;

    private void Start()
    {
        StartingOutfits();
    }

    private void StartingOutfits()
    {
        _bottomIndex = _topIndex = _hairIndex = _hatIndex = 0;

        if (bottomOutfits is {Count: > 0})
        {
            _currentBottom = bottomOutfits[_bottomIndex];
            outfitHandler.SetOutfit(_currentBottom);
        }

        if (topOutfits is {Count: > 0})
        {
            _currentTop = topOutfits[_topIndex];
            outfitHandler.SetOutfit(_currentTop);
        }

        if (hairOutfits is {Count: > 0})
        {
            _currentHair = hairOutfits[_hairIndex];
            outfitHandler.SetOutfit(_currentHair);
        }

        if (hatOutfits is {Count: > 0})
        {
            _currentHat = hatOutfits[_hatIndex];
            outfitHandler.SetOutfit(_currentHat);
        }
    }
    
    #region Outfit Selection

    public void NextOutfit(int type)
    {
        OutfitType typeEnum = (OutfitType) type;
        
        switch (typeEnum)
        {
            case OutfitType.Bottom:
                NextBottom();
                break;
            case OutfitType.Top:
                NextTop();
                break;
            case OutfitType.Hair:
                NextHair();
                break;
            case OutfitType.Hat:
                NextHat();
                break;
            default:
                break;
        }
    }
    public void PreviousOutfit(int type)
    {
        OutfitType typeEnum = (OutfitType) type;

        switch (typeEnum)
        {
            case OutfitType.Bottom:
                PreviousBottom();
                break;
            case OutfitType.Top:
                PreviousTop();
                break;
            case OutfitType.Hair:
                PreviousHair();
                break;
            case OutfitType.Hat:
                PreviousHat();
                break;
            default:
                break;
        }
    }

    private void ChangeOutfit<T>(bool next, ref int index, ref List<T> outfits, ref T currentOutfit, Action<T> onOutfitSet) where T : ItemOutfit
    {
        if (next)
        {
            index++;

            if (index >= outfits.Count)
                index = 0;
        }
        else
        {
            index--;

            if (index < 0)
                index = outfits.Count - 1;
        }

        currentOutfit = outfits[index];
        onOutfitSet?.Invoke(currentOutfit);
    }
    
    private void NextBottom()
    {
        ChangeOutfit(true, ref _bottomIndex, ref bottomOutfits, ref _currentBottom, x => outfitHandler.SetOutfit(x));
    }
    private void NextTop()
    {
        ChangeOutfit(true, ref _topIndex, ref topOutfits, ref _currentTop, x => outfitHandler.SetOutfit(x));
    }
    private void NextHair()
    {
        ChangeOutfit(true, ref _hairIndex, ref hairOutfits, ref _currentHair, x => outfitHandler.SetOutfit(x));
    }
    private void NextHat()
    {
        ChangeOutfit(true, ref _hatIndex, ref hatOutfits, ref _currentHat, x => outfitHandler.SetOutfit(x));
    }

    private void PreviousBottom()
    {
        ChangeOutfit(false, ref _bottomIndex, ref bottomOutfits, ref _currentBottom, x => outfitHandler.SetOutfit(x));
    }
    private void PreviousTop()
    {
        ChangeOutfit(false, ref _topIndex, ref topOutfits, ref _currentTop, x => outfitHandler.SetOutfit(x));
    }
    private void PreviousHair()
    {
        ChangeOutfit(false, ref _hairIndex, ref hairOutfits, ref _currentHair, x => outfitHandler.SetOutfit(x));
    }
    private void PreviousHat()
    {
        ChangeOutfit(false, ref _hatIndex, ref hatOutfits, ref _currentHat, x => outfitHandler.SetOutfit(x));
    }
    #endregion

    public void ClearOutfit(int type)
    {
        OutfitType typeEnum = (OutfitType)type;
        outfitHandler.ClearOutfit(typeEnum);
    }
}

[Serializable]
public enum OutfitType
{
    Bottom = 0,
    Top = 1,
    Hair = 2,
    Hat = 3
}