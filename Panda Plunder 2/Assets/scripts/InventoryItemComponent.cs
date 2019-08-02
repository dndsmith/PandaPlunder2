using UnityEngine;
using UnityEngine.UI;

// Game 2

/*
 *  This script is attached to a 3D GameObject that can be turned into an item.
 *  
 *  The information from this script is copied to an instance of an InventoryItem because
 *  when a GameObject is stashed into an inventory, it is destroyed.
 */

public class InventoryItemComponent : MonoBehaviour
{
    public string type;
    public Sprite icon;
    public GameObject spawnPrefab;
}
