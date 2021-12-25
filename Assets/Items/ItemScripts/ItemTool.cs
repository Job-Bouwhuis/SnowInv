using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Items/New Item"), Serializable]
public class ItemTool : ScriptableObject, ImyItem, ImyTool
{

    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public Sprite ItemSprite { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public string HarvestType { get; set; }
    public int HarvestDamage { get; set; }
    public int SecondaryDamage { get; set; }

    public void TakeDamage(int damage)
    {

    }

    public void Break()
    {
        throw new NotImplementedException();
    }
}

[CreateAssetMenu(fileName = "New Item DateBase", menuName = "Assets/DataBase/Item DataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemTool> Items;
}
