using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveInventoryItem : MonoBehaviour
{
    public static MoveInventoryItem move;

    public ItemTool holding;
    public Canvas invCanvas;
    public Image holdingTexMap;

    private void Awake()
    {
        move = this;
    }

    private void Update()
    {
        if(holding != null)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(invCanvas.transform as RectTransform, Input.mousePosition, invCanvas.worldCamera, out pos);
            transform.position = invCanvas.transform.TransformPoint(pos);

            holdingTexMap.enabled = true;
            holdingTexMap.sprite = holding.ItemSprite;
        }
        else
        {
            holdingTexMap.sprite = null;
            holdingTexMap.enabled = false;
        }
    }

}
