using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public BaseItem baseItem;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            var i = other.GetComponentsInChildren<InventoryManager>();
            var inv = i[0];
            if (inv != null)
            {
                bool result = inv.AddItem(baseItem);

                if (result)
                    Destroy(this.gameObject);
                else
                    Debug.Log("inventory full");
            }
        }
        catch
        {

        }
    }
}
