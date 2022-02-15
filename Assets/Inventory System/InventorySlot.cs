using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int slotIndex;
    public BaseItem holding;

    public Image slotHoldingImage;

    public Text stackText;
    public int stackSize;

    [Header("HotbarLink")]
    public bool isHotbarLink = false;
    public HotbarSlot hotbarSlot;

    public void Init(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public void Update()
    {
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if (stackSize <= 1)
            stackText.enabled = false;
        else
            stackText.enabled = true;

        if (holding != null)
        {
            slotHoldingImage.enabled = true;
            slotHoldingImage.sprite = holding.ItemSprite;

            if (isHotbarLink)
            {
                hotbarSlot.slotHoldingImage.enabled = true;
                hotbarSlot.holding = holding;
                hotbarSlot.slotHoldingImage.sprite = holding.ItemSprite;
            }
        }
        else
        {
            slotHoldingImage.enabled = false;
            if (isHotbarLink)
            {
                hotbarSlot.slotHoldingImage.enabled = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var mouse = MoveInventoryItem.mouse;
        BaseItem mouseItem = mouse.holding;
        int stackCount = mouse.StackCount;
        mouse.holding = holding;
        mouse.StackCount = stackSize;

        if (mouseItem != null)
        {
            holding = mouseItem;
            stackSize = stackCount;
            EnableDesc();
        }
        else
        {
            holding = null;
            stackSize = 0;
        }
           
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
