using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemEquipment equipment;
    public ItemTool tool;

    public BaseItem baseItem;

    public IMyItem item;

    private void Awake()
    {
        //if(equipment == null)
        //    item = tool;
        //else
        //    item = equipment;

    }
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
