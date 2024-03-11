using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryItem inventoryItem;
    
    //Instead of OnMouseEnter and OnMouseExit, I use OnPointerEnter and OnPointerExit because these work in UI
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.instance.SetAndShowToolTip(inventoryItem.item.title);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.instance.HideTooltip();
    }
}