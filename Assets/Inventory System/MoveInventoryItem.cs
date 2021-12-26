using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveInventoryItem : MonoBehaviour
{
    public static MoveInventoryItem mouse;

    public IMyItem holding;
    public DescriptionBoxSender descriptionBoxSender;

    [SerializeField]
    Canvas invCanvas;

    public Image holdingTexMap;

    [SerializeField]
    GameObject slotItemDescription;
    public SlotItemDescription itemDesc;

    public void Awake()
    {
        mouse = this;
        descriptionBoxSender = new DescriptionBoxSender();
    }

    public void Update()
    {

        //set variable pos to mouse position translated from camera position, to canvas position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(invCanvas.transform as RectTransform, Input.mousePosition, invCanvas.worldCamera, out Vector2 pos);
        if (holding != null)
        {
            holdingTexMap.enabled = true;
            holdingTexMap.sprite = holding.ItemSprite;
        }
        else
        {
            holdingTexMap.sprite = null;
            holdingTexMap.enabled = false;
        }

        if (descriptionBoxSender.sender != null || holding != null)
        {
            transform.position = invCanvas.transform.TransformPoint(pos);
            slotItemDescription.SetActive(true);
        }
            
        else
            slotItemDescription.SetActive(false);

    }
}

public class DescriptionBoxSender
{
    public IMyItem item;
    public InventorySlot sender;

    readonly MoveInventoryItem mouse = MoveInventoryItem.mouse;

    public void Set(InventorySlot sender)
    {
        if (mouse.descriptionBoxSender.sender != sender)
        {
            this.sender = sender;
            item = sender.holding;
            mouse.itemDesc.UpdateDescriptionBox(item);
        }
    }

    public void Clear(InventorySlot sender)
    {
        if (mouse.descriptionBoxSender.sender == sender)
            mouse.descriptionBoxSender.sender = null;
    }
}
