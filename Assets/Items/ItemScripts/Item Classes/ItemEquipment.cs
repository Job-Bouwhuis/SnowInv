using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Assets/Items/New Equipment")]
public class ItemEquipment : ScriptableObject, IMyItem, IMyEquipment
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public Sprite ItemSprite { get; set; }
    public string ItemType { get; set; }
    public int ArmorValue { get; set; }
    public string ArmorType { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }

    public void Break()
    {
        throw new System.NotImplementedException();
    }
}
