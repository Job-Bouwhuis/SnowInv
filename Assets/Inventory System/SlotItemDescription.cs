using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItemDescription : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    
    public void UpdateDescriptionBox(IMyItem item)
    {
        var tool = item as ItemTool;
        if (tool != null)
        {
            Debug.Log("Selected Tool Item");
            Tool(tool);
            return;
        }
        var equipment = item as ItemEquipment;
        if (equipment != null)
        {
            Debug.Log("Selected Equipment Item");
            Equipment(equipment);
            return;
        }
        

    }

    public void Tool(ItemTool item)
    {
        text1.text = $"Name: {item.Name}";
        text2.text = $"Cost: {item.NuggetValue}";

        text3.text = $"Harvest Type: {item.HarvestType}";
        text4.text = $"Harvest Damage: {item.HarvestDamage}";
        
    }

    public void Equipment(ItemEquipment item)
    {
        text1.text = $"Name: {item.Name}";
        text2.text = $"Cost: {item.NuggetValue}";

        text3.text = $"Resistance Type: {item.ArmorType}";
        text4.text = $"Resistance: {item.ArmorValue}";
    }

}
