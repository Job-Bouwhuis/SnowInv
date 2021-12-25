using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempAddItemButton : MonoBehaviour
{
    public InventoryManager inv;
    public ItemEquipment item;

    public void TEMPAddItem()
    {
        inv.AddItem(item);
    }
}
