using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IMyItem
{
    public string ItemType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public Sprite ItemSprite { get; set; }
}

public interface IMyTool
{
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public string HarvestType { get; set; }
    public int HarvestDamage { get; set; }
    public int SecondaryDamage { get; set; }
    public void TakeDamage(int damage);
    public void Break();
}

public interface IMyEquipment
{
    public int ArmorValue { get; set; }
    public string ArmorType { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public void Break();
}

