using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int slots = 0;

    public GameObject SlotParent;

    public List<GameObject> slotsList = new List<GameObject>();

    private void Awake()
    {
        foreach (Slot slot in SlotParent.GetComponentsInChildren<Slot>())
        {
            if (!slotsList.Contains(slot.gameObject))
                slotsList.Add(slot.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        slots = slotsList.Count;

        for (int i = 0; i < slotsList.Count; i++)
        {
            GameObject slot = slotsList[i];
            slot.GetComponent<Slot>().Init(i);
        }
    }

    public bool AddItem(ItemTool item)
    {
        foreach (var s in slotsList)
        {
            var r = s.GetComponent<Slot>();
            if (r.holding != null)
                continue;
            else
            {
                r.holding = item;

                return true;
            }

        }
        return false;
    }

}
