using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int slotIndex;
    public IMyItem holding;

    public Image slotHoldingImage;

    [Header("HotbarLink")]
    [SerializeField]
    private bool isHotbarLink = false;
    [SerializeField]
    private HotbarSlot hotbarSlot;

    public void Init(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public void Update()
    {
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
