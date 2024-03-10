using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class InventoryOutfitSlot : InventorySlot, IBeginDragHandler
{
    // [SerializeField] private UnityEvent<ItemOutfit> onOutfitSet;
    [SerializeField] private OutfitType outfitType;

    [SerializeField] private CharacterOutfitHandler playerOutfitHandler;
    [SerializeField] private CharacterOutfitHandler inventoryOutfitHandler;

    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if (eventData.pointerDrag.TryGetComponent<InventoryItem>(out var inventoryItem))
            {
                CheckOutfitHandlers(out bool playerHandler, out bool inventoryHandler);
                
                switch (outfitType)
                {
                    case OutfitType.Bottom:
                        if (TryCastOutfit<ItemOutfitBottom>(inventoryItem.item, out var bottomOutfit))
                        {
                            inventoryItem.parentAfterDrag = transform;
                            
                            if(playerHandler)
                                playerOutfitHandler.SetOutfit(bottomOutfit);
                            if(inventoryHandler)
                                inventoryOutfitHandler.SetOutfit(bottomOutfit);

                            inventoryItem.aOnBeginDrag = () =>
                            {
                                playerOutfitHandler.ClearOutfit(OutfitType.Bottom);
                                inventoryOutfitHandler.ClearOutfit(OutfitType.Bottom);
                            };
                        }
                        break;
                    
                    case OutfitType.Top:
                        if (TryCastOutfit<ItemOutfitTop>(inventoryItem.item, out var topOutfit))
                        {
                            inventoryItem.parentAfterDrag = transform;
                            
                            if(playerHandler)
                                playerOutfitHandler.SetOutfit(topOutfit);
                            if(inventoryHandler)
                                inventoryOutfitHandler.SetOutfit(topOutfit);
                            
                            inventoryItem.aOnBeginDrag = () =>
                            {
                                playerOutfitHandler.ClearOutfit(OutfitType.Top);
                                inventoryOutfitHandler.ClearOutfit(OutfitType.Top);
                            };
                        }
                        break;
                    
                    case OutfitType.Hair:
                        if (TryCastOutfit<ItemOutfitHair>(inventoryItem.item, out var hairOutfit))
                        {
                            inventoryItem.parentAfterDrag = transform;
                            
                            if(playerHandler)
                                playerOutfitHandler.SetOutfit(hairOutfit);
                            if(inventoryHandler)
                                inventoryOutfitHandler.SetOutfit(hairOutfit);
                            
                            inventoryItem.aOnBeginDrag = () =>
                            {
                                playerOutfitHandler.ClearOutfit(OutfitType.Hair);
                                inventoryOutfitHandler.ClearOutfit(OutfitType.Hair);
                            };
                        }
                        break;
                    
                    case OutfitType.Hat:
                        if (TryCastOutfit<ItemOutfitHat>(inventoryItem.item, out var hatOutfit))
                        {
                            inventoryItem.parentAfterDrag = transform;
                            
                            if(playerHandler)
                                playerOutfitHandler.SetOutfit(hatOutfit);
                            if(inventoryHandler)
                                inventoryOutfitHandler.SetOutfit(hatOutfit);
                            
                            inventoryItem.aOnBeginDrag = () =>
                            {
                                playerOutfitHandler.ClearOutfit(OutfitType.Hat);
                                inventoryOutfitHandler.ClearOutfit(OutfitType.Hat);
                            };
                        }
                        break;
                }
            }
        }
        
        Debug.Log("Outfit Dropped");
    }
    
    private void CheckOutfitHandlers(out bool player, out bool inventory)
    {
        player = playerOutfitHandler != null;
        inventory = inventoryOutfitHandler != null;
    }

    private bool TryCastOutfit<T>(Item outfit, out T specificOutfit) where T : ItemOutfit
    {
        try
        {
            specificOutfit = (T) outfit;
            return true;
        }
        catch (Exception e)
        {
            specificOutfit = default;
            return false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging outfit");
    }
}