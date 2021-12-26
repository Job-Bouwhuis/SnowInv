using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Items/New Item"), Serializable]
public class ItemTool : BaseItem, IMyItem, IMyTool
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int NuggetValue { get; set; }
    public Sprite ItemSprite { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public string HarvestType { get; set; }
    public int HarvestDamage { get; set; }
    public int SecondaryDamage { get; set; }
    public string ItemType { get; set; }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public void Break()
    {
        throw new NotImplementedException();
    }
}


