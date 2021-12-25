using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public int slotIndex;
    public ItemTool holding;
    public Image slotHoldingImage;

    public void Init(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (holding != null)
            slotHoldingImage.sprite = holding.ItemSprite;
        else
            slotHoldingImage.sprite = null;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var mouse = MoveInventoryItem.move;

        ItemTool mouseItem = mouse.holding;

        mouse.holding = holding;

        if (mouseItem != null)
        {
            holding = mouseItem;
        }
        else
        {
            holding = null;
        }
    }
}
