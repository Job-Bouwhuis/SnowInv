using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Object Links")]
    public GameObject Player;
    public InventoryManager inventoryManager;

    [Header("Local Links")]
    public int slotIndex;
    public BaseItem holding;

    public Image slotHoldingImage;

    public Text stackText;
    public int stackSize;

    [Header("HotbarLink")]
    public bool isHotbarLink = false;
    public HotbarSlot hotbarSlot;


    private bool isMouseOver = false;


    public void Init(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public void Update()
    {
        UpdateSlot();

        if (isMouseOver && Input.GetKeyDown(KeyCode.Q) && holding != null)
        {
            ItemDropper.shared.DropItem(holding, stackSize, Player.transform.position);
            holding = null;
            stackSize = 0;
        }
    }

    public void UpdateSlot()
    {
        if (stackSize < 1)
        {
            stackText.enabled = false;
            if (isHotbarLink)
                hotbarSlot.stackText.enabled = false;
        }
        else
        {
            stackText.text = stackSize.ToString();
            stackText.enabled = true;
            if (isHotbarLink)
            {
                hotbarSlot.stackText.text = stackSize.ToString();
                hotbarSlot.stackText.enabled = true;
            }
        }
            

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
            stackSize = 0;
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
        BaseItem mouseItem = null;
        if(mouse.holding != null)
            mouseItem = mouse.holding;
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isHotbarLink)
            {
                foreach(var slot in inventoryManager.InventorySlots)
                {
                    if(slot.holding != null)
                        if (slot.holding.Equals(holding) && slot.stackSize + stackSize <= slot.holding.maxStackSize)
                        {
                          
                        }
                }
            }
        }
        if (eventData.button == PointerEventData.InputButton.Left || stackSize <= 1 || mouseItem != null)
        {
            if (mouseItem != null)
            {
                if (holding != null && !mouseItem.Equals(holding))
                {
                    int mouseStackCount = mouse.stackCount;
                    mouse.holding = holding;
                    mouse.stackCount = stackSize;
                    holding = mouseItem;
                    stackSize = mouseStackCount;
                    return;
                }
                if(holding == null)
                {
                    if(eventData.button == PointerEventData.InputButton.Right && mouse.stackCount > 1)
                    {
                        holding = mouseItem;
                        stackSize = mouse.stackCount / 2;
                        stackSize += mouse.stackCount % 2;

                        mouse.stackCount /= 2;
                        return;
                    }
                    holding = mouseItem;
                    stackSize = mouse.stackCount;
                    mouse.holding = null;
                    mouse.stackCount = 0;
                }
                else if (holding.maxStackSize >= stackSize + mouse.stackCount)
                {
                    stackSize += mouse.stackCount;
                    mouse.holding = null;
                    mouse.stackCount = 0;
                }
                else
                {
                    int remCap = holding.maxStackSize - stackSize;
                    stackSize += remCap;
                    mouse.stackCount -= remCap;
                    return;
                }
                EnableDesc();
            }
            else
            {

                mouse.holding = holding;
                mouse.stackCount = stackSize;

                holding = null;
                stackSize = 0;
            }
        }
        else
        {
            mouse.holding = holding;
            mouse.stackCount = stackSize / 2;
            mouse.stackCount += stackSize % 2;

            stackSize /= 2;
        }

        UpdateSlot();
    }

    void EnableDesc()
    {
        if (holding != null)
            MoveInventoryItem.mouse.descriptionBoxSender.Set(this);   
    }
    void DissableDesc()
    {
        MoveInventoryItem.mouse.descriptionBoxSender.Clear(this);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableDesc();
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DissableDesc();
        isMouseOver = false;
    }
}
