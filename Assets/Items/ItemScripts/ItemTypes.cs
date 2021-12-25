using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface ImyItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public Sprite ItemSprite { get; set; }
}

public interface ImyTool
{
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public string HarvestType { get; set; }
    public int HarvestDamage { get; set; }
    public int SecondaryDamage { get; set; }
    public void Break();
}

