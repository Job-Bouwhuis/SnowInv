using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public List<HotbarSlot> slots = new List<HotbarSlot>();
    public HotbarSlot selected;
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        foreach (HotbarSlot slot in GetComponentsInChildren<HotbarSlot>())
             slots.Add(slot);

        foreach (HotbarSlot slot in slots)
        {
            slot.selectedArrow.enabled = false;
        }

        selected = slots[index];
        selected.selectedArrow.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInput = Input.GetAxis("Mouse ScrollWheel");
        if (mouseInput != 0)
        {
            if (mouseInput == -0.1f)
            {
                if (index == slots.Count - 1)
                    index = 0;
                else
                    index++;
            }
            else if (index == 0)
                index = slots.Count - 1;
            else
                index--;

            selected.selectedArrow.enabled = false;
            selected = slots[index];
            selected.selectedArrow.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Determaining Item");

            var tool = selected.holding as ItemTool;
            if (tool != null)
            {
                tool.Use();
                return;
            }
            var armor = selected.holding as ItemArmor;
            if (armor != null)
            {
                armor.Break();
            }
        }



    }
}
