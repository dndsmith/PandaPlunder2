using UnityEngine;
using System.Collections.Generic;

// Game 2

/*
 *  Represents a variable with operations Assign and GetValue.
 *  Currently only InventoryItems as values. This could be generalized.
 *  Currently does not check for same type among all InventoryItems when assigned.
 */

public class Variable : MonoBehaviour
{
    // assign name and icon in Inspector
    List<InventoryItem> values = new List<InventoryItem>();
    public string varName;
    public Sprite varIcon;
    private string type = null;

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

    public bool ContainsItem(InventoryItem item)
    {
        return values.Contains(item);
    }
}
