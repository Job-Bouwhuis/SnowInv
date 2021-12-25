using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item DateBase", menuName = "Assets/DataBase/Item DataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<IMyItem> Items;
}

