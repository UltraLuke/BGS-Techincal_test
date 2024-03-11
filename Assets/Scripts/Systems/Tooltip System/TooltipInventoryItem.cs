using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryItem inventoryItem;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.instance.SetAndShowToolTip(inventoryItem.item.title);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.instance.HideTooltip();
    }
}