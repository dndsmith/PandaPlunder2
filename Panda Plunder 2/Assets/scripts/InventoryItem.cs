using UnityEngine;
using System.Collections;

// This is a workaround for storing inventory items in a stack when their gameobjects get destroyed

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
