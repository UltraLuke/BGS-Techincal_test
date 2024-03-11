using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private RectTransform backgroundRectTransform;
    [SerializeField] private float paddingHorizontal;
    [SerializeField] private float paddingVertical;

    public static TooltipManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);            
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
        Vector2 backgroundSize = new Vector2(textComponent.preferredWidth + paddingHorizontal * 2f, textComponent.preferredHeight + paddingVertical * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = "";
    }
}
