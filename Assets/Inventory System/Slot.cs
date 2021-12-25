using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int slotIndex;
    public IMyItem holding;

    public Image slotHoldingImage;

    public void Init(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public void Update()
    {
        if (holding != null)
        {
            slotHoldingImage.sprite = holding.ItemSprite;
        }
        else
            slotHoldingImage.sprite = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var mouse = MoveInventoryItem.mouse;
        IMyItem mouseItem = mouse.holding;
        mouse.holding = holding;

        if (mouseItem != null)
        {
            holding = mouseItem;
            EnableDesc();
        }
        else
            holding = null;
    }


    void EnableDesc()
    {
        var mouse = MoveInventoryItem.mouse;
        if (holding != null)
        {
            mouse.descriptionBoxSender.Set(this);
        }
    }
    void DissableDesc()
    {
        var mouse = MoveInventoryItem.mouse;
        mouse.descriptionBoxSender.Clear(this);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableDesc();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DissableDesc();
    }
}
