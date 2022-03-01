using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    public BaseItem baseItem;
    public int itemCount;
    public bool CanPickup = false;
    private void OnTriggerEnter(Collider other)
    {
        if (CanPickup)
            try
            {
                var i = other.GetComponentsInChildren<InventoryManager>();
                var inv = i[0];
                if (inv != null)
                {
                    bool result = inv.AddItem(baseItem, itemCount, true);

                    if (result)
                        Destroy(gameObject);
                    else
                        Debug.Log("inventory full");
                }
            }
            catch { }
    }
}
