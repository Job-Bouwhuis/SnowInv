using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempAddItemButton : MonoBehaviour
{
    public InventoryManager inv;
    public BaseItem item;

    public void TEMPAddItem()
    {
        inv.AddItem(item, 1);
    }
    public void TEMPRemoveItem()
    {
        inv.RemoveItem(item, 1);
    }
}
