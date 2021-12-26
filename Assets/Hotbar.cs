using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public List<HotbarSlot> slots = new List<HotbarSlot>();


    // Start is called before the first frame update
    void Start()
    {
        foreach(HotbarSlot slot in GetComponentsInChildren<HotbarSlot>())
            slots.Add(slot);

        foreach(HotbarSlot slot in slots)
        {
            slot.selectedArrow.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
