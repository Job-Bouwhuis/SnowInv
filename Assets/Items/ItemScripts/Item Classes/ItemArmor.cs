using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Assets/Items/New Equipment")]
public class ItemArmor : BaseItem
{
    public int ArmorValue;
    public string ArmorType;
    public int MaxDurability;
    public int Durability;

    public void Break()
    {
        throw new System.NotImplementedException();
    }
}
