﻿using UnityEngine;
using System.Collections.Generic;

// Prob doesn't have to inherit from MonoBehaviour

public class Variable : MonoBehaviour
{
    // assign name and icon in Inspector
    List<InventoryItem> values = new List<InventoryItem>();
    public string varName;
    public Sprite varIcon;
    private string type;

    public void Assign(List<InventoryItem> items)
    {
        values.Clear();
        values = items;
        if (values.Count != 0)
        {
            type = values[0].type;
        }
        Debug.Log($"assignment value is {values.Count}");
        // sort?
    }

    public InventoryItem[] GetValue()
    {
        return values.ToArray();
    }

    public string GetItemType()
    {
        return type;
    }
}