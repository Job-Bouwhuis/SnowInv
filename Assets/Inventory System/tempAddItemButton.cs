using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempAddItemButton : MonoBehaviour
{
    public InventoryManager inv;
    public BaseItem item;

    public void TEMPAddItem()
    {
        inv.AddItem(item);
    }
    public void TEMPRemoveItem()
    {
        inv.RemoveItem(item);
    }
}
