using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BaseItem : ScriptableObject, IDisposable
{
    public string Name;
    public string Description;
    public int maxStackCount;
    public int stackCount;
    public int NuggetValue;
    public Sprite ItemSprite;

    public void Dispose()
    {
        Name = null;
        Description = null;
        NuggetValue = 0;
        ItemSprite = null;
        maxStackCount = 0;
        stackCount = 0;
    }
}

public class IMyResource
{
    public string MaterialType { get; set; }
}

public interface IMyItemUsage
{
    public void Use();
}
