using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemTool item;

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
