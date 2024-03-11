using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private string message;

    private void OnMouseEnter()
    {
        TooltipManager.instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
        TooltipManager.instance.HideTooltip();
    }
}