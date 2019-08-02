using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Represents an item that can be stored in an inventory (e.g. gems).
 *  Items have a type and an icon associated with them.
 *  Type should be formatted as <modifier_1>...<modifier_n><tag>
 *  --> E.g. greengem is of the form <modifier_1><tag>
 */

public class InventoryItem
{
    public string type;
    public Sprite icon;
    public GameObject spawnPrefab;

    public InventoryItem(InventoryItemComponent item)
    {
        type = item.type;
        icon = item.icon;
        spawnPrefab = item.spawnPrefab;
    }

    public void PrintItem()
    {
        Debug.Log(type);
        Debug.Log(icon);
        Debug.Log(spawnPrefab);
    }
}
