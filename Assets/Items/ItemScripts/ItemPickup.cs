using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemEquipment equipment;
    public ItemTool tool;

    public IMyItem item;

    private void Awake()
    {
        if(equipment == null)
            item = tool as IMyItem;
        else
            item = tool as IMyItem;
    }
    private void OnTriggerEnter(Collider other)
    {
        var i = other.GetComponentsInChildren<InventoryManager>();
        var inv = i[0];
        if (inv != null)
        {
            bool result = inv.AddItem(item);

            if(result)
                Destroy(this.gameObject);
        }
    }
}
