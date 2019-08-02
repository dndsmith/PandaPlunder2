using UnityEngine;
using System.Collections.Generic;

// Game 2

/*
 *  Represents an inventory (e.g. player inventory) which has multiple boxes for storing items.
 *  Can "stash" items, meaning that an item is added to the inventory.
 */

public class Inventory : MonoBehaviour
{
    public InventoryBox[] inventoryBoxes;

    //***************** 4 VERSIONS OF STASH... *****************//

    public bool Stash(InventoryItemComponent item)
    {
        if (item == null) return false;
        // check if any of the boxes already contain item type
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (item.type.Equals(box.GetItemType()))
            {
                box.AddItem(item);
                Destroy(item.gameObject);
                return true;
            }
        }

        // check for first available box
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (box.AddItem(item))
            {
                Destroy(item.gameObject);
                return true;
            }
        }
        return false;
    }

    public bool Stash(InventoryItem item)
    {
        if (item == null) return false;
        // check if any of the boxes already contain item type
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (item.type.Equals(box.GetItemType()))
            {
                box.AddItem(item);
                return true;
            }
        }

        // check for first available box
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (box.AddItem(item))
            {
                return true;
            }
        }
        return false;
    }

    public bool Stash(InventoryItemComponent[] items)
    {
        if (items == null) return false;
        // check if any of the boxes already contain item type
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (items[0].type.Equals(box.GetItemType()))
            {
                box.AddItems(items);
                foreach(InventoryItemComponent item in items)
                {
                    Destroy(item.gameObject);
                }
                return true;
            }
        }

        // check for first available box
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (box.AddItems(items))
            {
                foreach (InventoryItemComponent item in items)
                {
                    Destroy(item.gameObject);
                }
                return true;
            }
        }
        return false;
    }

    public bool Stash(InventoryItem[] items)
    {
        if (items == null) return false;
        // check if any of the boxes already contain item type
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (items[0].type.Equals(box.GetItemType()))
            {
                box.AddItems(items);
                return true;
            }
        }

        // check for first available box
        foreach (InventoryBox box in inventoryBoxes)
        {
            if (box.AddItems(items))
            {
                return true;
            }
        }
        return false;
    }


    // ***************** END OF STASH **************//

    public bool ContainsItem(InventoryItem item)
    {
        foreach(InventoryBox box in inventoryBoxes)
        {
            if (box.ContainsItem(item)) return true;
        }
        return false;
    }

    public bool ContainsItems(InventoryItem[] items)
    {
        if (items == null) return false;
        bool success = false;
        foreach(InventoryItem item in items)
        {
            success &= ContainsItem(item);
        }
        return success;

    }
}
