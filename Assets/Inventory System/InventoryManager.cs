using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int slots = 0;

    public GameObject SlotParent;
    public GameObject HotbarSlotLinkParent;
    public GameObject ItemDropPrefab;
    public ItemUseEventHandler ItemUseEvent { get; private set; }

    public List<InventorySlot> InventorySlots { get; private set; } = new List<InventorySlot>();

    public List<InventorySlot> HotbarSlots { get; private set; } = new List<InventorySlot>();



    public void Awake()
    {
        ItemUseEvent = new ItemUseEventHandler();
        ItemUseEvent.AddListener(ItemUseEvent.Content);
        foreach (InventorySlot slot in HotbarSlotLinkParent.GetComponentsInChildren<InventorySlot>())
        {
            if (!HotbarSlots.Contains(slot))
                HotbarSlots.Add(slot);
        }

        foreach (InventorySlot slot in SlotParent.GetComponentsInChildren<InventorySlot>())
        {
            if (!InventorySlots.Contains(slot))
                InventorySlots.Add(slot);
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        slots = InventorySlots.Count;

        for (int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].Init(i);
        }
    }

    public bool AddItem(BaseItem item, int count = 1, bool isItemPickup = false)
    {
        try
        {
            //foreach hotbarslot
            foreach (InventorySlot s in HotbarSlots)
            {
                //if slot is holding item
                if (s.holding != null)
                {
                    if (s.stackSize == s.holding.maxStackSize || isItemPickup)
                        continue;
                    if (s.holding.name == item.name && s.stackSize < s.holding.maxStackSize)
                    {
                        s.stackSize += count;
                        s.UpdateSlot();
                        return true;
                    }
                    else
                    {
                        int rem = s.holding.maxStackSize - s.stackSize;
                        s.stackSize += rem;
                        count -= rem;
                        s.UpdateSlot();
                        continue;
                    }
                }
                else
                {
                    //fill slot with given item
                    s.holding = item;
                    s.stackSize += count;
                    //if inventory screen is open, this will happen automatically. but if it is closed it does not update any inventory slots.
                    //we do this so the item appears in the hotbar when picked up
                    s.UpdateSlot();
                    return true;
                }
            }

            //executes this code if hotbar is full
            //for every inventory slot
            foreach (InventorySlot s in InventorySlots)
            {
                //if its not empty continue to the next slot
                if (s.holding != null)
                {
                    if (s.holding.name == item.name && s.stackSize < s.holding.maxStackSize)
                    {
                        s.stackSize += count;
                        s.UpdateSlot();
                        return true;
                    }
                    else
                    {
                        int rem = s.holding.maxStackSize - s.stackSize;
                        s.stackSize += rem;
                        count -= rem;
                        continue;
                    }
                }
                else
                {
                    //if it is empty fill slot with specified item
                    s.holding = item;
                    s.stackSize += count;
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

    public int[] Range(int num)
    {
        List<int> range = new List<int>();
        for (int i = 0; i < num; i++)
            range.Add(i);
        return range.ToArray();
    }

    public async Task<bool> RemoveItem(BaseItem item, int count = 1)
    {
        return await Task.Run(() =>
        {
            //first go over all hotbar slots if the item exists there
            foreach (var slot in HotbarSlots)
            {
                if (slot.holding == null)
                    continue;
                if (!slot.holding.Equals(item))
                    continue;

                //if the item is found in hotbar, remove as many items from the stack as possible while staying within the limit of the given count variable
                foreach (int i in Range(count))
                {
                    if (slot.stackSize > 0 && count >= 1)
                    {
                        slot.stackSize--;
                        count--;
                    }
                    //when either the stack is deleted or the count has reached 0
                    // then break the loop
                    else
                        break;
                }
                //if there are still items to remove from the invnetory, then do that
                if (count >= 1)
                {
                    if (slot.stackSize == 0)
                        slot.holding = null;
                    continue;
                }
                    
                //otherwise return from the method
                else
                {
                    if (slot.stackSize == 0)
                        slot.holding = null;
                    return true;
                }
                    
            }
            //if the execution reaches here then the requested item was not in the hotbar. now we check if it exists in the inventory
            foreach (var slot in InventorySlots)
            {
                //just repeat the previous foreach statement, but for inventory slots this time
                if (slot.holding == null)
                    continue;
                if (!slot.holding.Equals(item))
                    continue;

                //if the item is found in the inventory, remove as many items from the stack as possible while staying within the limit of the given count variable
                foreach (int i in Range(count))
                {
                    if (slot.stackSize > 0 && count >= 1)
                    {
                        slot.stackSize--;
                        count--;
                    }
                    //when either the stack is deleted or the count has reached 0
                    // then break the loop
                    else
                        break;
                }
                //if there are still items to remove from the invnetory, then do that
                if (count >= 1)
                {
                    if (slot.stackSize == 0)
                        slot.holding = null;
                    continue;
                }
                //otherwise return from the method
                else
                {
                    if (slot.stackSize == 0)
                        slot.holding = null;
                    return true;
                }
                    
            }
            return false;
        });


       
    }

    public bool IsHotbarFull()
    {
        foreach (InventorySlot s in HotbarSlots)
        {
            if (s.holding == null)
                return false;
            else
                continue;
        }
        return true;
    }
}


public class ItemDropper
{
    public static ItemDropper shared;

    private GameObject DroppedItem;
    internal void Init(GameObject dropPrefab)
    {
        shared = this;
        DroppedItem = dropPrefab;
    }

    public void DropItem(BaseItem item, int count, Vector3 position)
    {
        GameObject newDrop = GameObject.Instantiate(DroppedItem, position + Vector3.up, Quaternion.identity);
        ItemPickup ip = newDrop.GetComponent<ItemPickup>();
        if (ip == null)
        {
            GameObject.Destroy(newDrop);
        }
        ip.baseItem = item;
        ip.itemCount = count;

        System.Threading.Tasks.Task.Run(async () =>
        {
            await System.Threading.Tasks.Task.Delay(1500);
            ip.CanPickup = true;
        });
        
    }
}
