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

    
    public void UpdateDescriptionBoxTool(IMyItem item)
    {
        text1.text = $"Name: {item.Name}";
        text2.text = $"Cost: {item.Value}";

        var tool = item as ItemTool;
        text3.text = $"Harvest Type: {tool.HarvestType}";
        text4.text = $"Harvest Damage: {tool.HarvestDamage}";
        
    }
}
