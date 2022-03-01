using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BaseItem : ScriptableObject, IDisposable
{
    public int id;
    public string Name;
    public string Description;
    public int maxStackSize = 64;
    public int NuggetValue;
    public Sprite ItemSprite;

    public void Dispose()
    {
        maxStackSize = 0;
        Name = null;
        Description = null;
        NuggetValue = 0;
        ItemSprite = null;
    }
}

public class IMyResource
{
    public string MaterialType { get; set; }
}
