using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int slots = 0;

    public GameObject SlotParent;
    public GameObject HotbarSlotLinkParent;

    public List<InventorySlot> slotsList = new List<InventorySlot>();
    public List<InventorySlot> hotbarSlots = new List<InventorySlot>();



    public void Awake()
    {
        foreach (InventorySlot slot in HotbarSlotLinkParent.GetComponentsInChildren<InventorySlot>())
        {
            if (!hotbarSlots.Contains(slot))
                hotbarSlots.Add(slot);
        }

        foreach (InventorySlot slot in SlotParent.GetComponentsInChildren<InventorySlot>())
        {
            if (!slotsList.Contains(slot))
                slotsList.Add(slot);
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        slots = slotsList.Count;

        for (int i = 0; i < slotsList.Count; i++)
        {
            slotsList[i].Init(i);
        }
    }

    public bool AddItem(BaseItem item)
    {
        try
        {
            if (!IsHotbarFull()) 
            {
                foreach(InventorySlot s in hotbarSlots)
                {
                    if (s.holding != null)
                        continue;
                    else
                    {
                        s.holding = item;
                        s.UpdateSlot();
                        return true;
                    }
                }
            }

            foreach (InventorySlot s in slotsList)
            {
                if (s.holding != null)
                    continue;
                else
                {
                    s.holding = item;

                    return true;
                }

            }
            return false;
        }
        catch
        {
            Debug.Log("Inventory is full");
            return false;
        }
    }

    public bool RemoveItem(BaseItem item)
    {
        for(int h = 0; h < hotbarSlots.Count; h++)
        {
            if(hotbarSlots[h].holding == item)
            {
                hotbarSlots.RemoveAt(h);
                return true;
            }
        }
        Debug.Log("Item Not in Hotbar");
        for (int i = 0; i < slotsList.Count; i++)
        {
            if(slotsList[i].holding == item)
            {
                slotsList.RemoveAt(i);
                return true;
            }
        }
        Debug.Log("Item not in inventory");
        return false;
    }

    public bool IsHotbarFull()
    {
        foreach(InventorySlot s in hotbarSlots)
        {
            if (s.holding == null)
                return false;
            else
                continue;
        }
        return true;
    }

}
