using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int slots = 0;

    public GameObject SlotParent;

    public List<GameObject> slotsList = new List<GameObject>();

    public void Awake()
    {
        foreach (InventorySlot slot in SlotParent.GetComponentsInChildren<InventorySlot>())
        {
            if (!slotsList.Contains(slot.gameObject))
                slotsList.Add(slot.gameObject);
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        slots = slotsList.Count;

        for (int i = 0; i < slotsList.Count; i++)
        {
            GameObject slot = slotsList[i];
            slot.GetComponent<InventorySlot>().Init(i);
        }
    }

    public bool AddItem(BaseItem item)
    {
        try
        {
            foreach (var s in slotsList)
            {
                var r = s.GetComponent<InventorySlot>();
                if (r.holding != null)
                    continue;
                else
                {
                    r.holding = item as IMyItem;

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

}
