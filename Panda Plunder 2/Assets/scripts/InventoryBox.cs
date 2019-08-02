using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Game 2

/*
 *  Represents a box within an inventory.
 *  Functions as a drop zone as well.
 */

// I have been informed that returning null collections is bad practice...oh well
// TODO MAYBE: refactor so that methods return empty array/list

public class InventoryBox : MonoBehaviour
{
    public GameObject itemStackPrefab; // this is to create the 2D item stack that can be dragged around
    private GameObject residentObject = null;
    private DropZone DZ;

    private void Awake()
    {
        DZ = GetComponentInChildren<DropZone>();
    }

    public bool AddItem(InventoryItemComponent item)
    {
        if (item == null) return false;
        else if (residentObject == null) CreateStack();
        return residentObject.GetComponent<ItemStack>().AddItem(item);
    }

    public bool AddItem(InventoryItem item)
    {
        if (item == null) return false;
        else if (residentObject == null) CreateStack();
        return residentObject.GetComponent<ItemStack>().AddItem(item);
    }

    public bool AddItems(InventoryItemComponent[] items)
    {
        if (items == null) return false;
        else if (residentObject == null) CreateStack();
        return residentObject.GetComponent<ItemStack>().AddItems(items);
    }

    public bool AddItems(InventoryItem [] items)
    {
        if (items == null) return false;
        else if (residentObject == null) CreateStack();
        return residentObject.GetComponent<ItemStack>().AddItems(items);
    }

    // don't ever use with VariableHolder drag item
    public InventoryItem RemoveItem()
    {
        if (residentObject != null && residentObject.GetComponent<ItemStack>() != null)
        {
            return residentObject.GetComponent<ItemStack>().RemoveItem();
        }
        else return null;
    }

    public InventoryItem[] RemoveItems(int num)
    {
        if (residentObject != null)
        {
            if (residentObject.GetComponent<ItemStack>() != null)
                return residentObject.GetComponent<ItemStack>().RemoveItems(num);
            else if (residentObject.GetComponent<VariableHolder>() != null)
                return residentObject.GetComponent<VariableHolder>().GetVariable().GetValue();
            else return null;
        }
        else return null;
    }

    public InventoryItem[] RemoveAllItems()
    {
        if (residentObject != null)
        {
            if (residentObject.GetComponent<ItemStack>() != null)
                return residentObject.GetComponent<ItemStack>().RemoveAllItems();
            else if (residentObject.GetComponent<VariableHolder>() != null)
                return residentObject.GetComponent<VariableHolder>().GetVariable().GetValue();
            else return null;
        }
        else return null;
    }

    public void SetResident(GameObject obj)
    {
        residentObject = obj;
    }

    public void CreateStack()
    {
        SetResident(Instantiate(itemStackPrefab, this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform));
        residentObject.GetComponent<DragItem>().DropInZone(DZ);
    }

    public string GetItemType()
    {
        if (residentObject != null)
        {
            if (residentObject.GetComponent<ItemStack>() != null)
                return residentObject.GetComponent<ItemStack>().GetItemType();
            else if (residentObject.GetComponent<VariableHolder>() != null)
                return residentObject.GetComponent<VariableHolder>().GetItemType();
            else return null;
        }
        else return null;
    }

    public void DestroyContents()
    {
        Destroy(residentObject);
    }

    public bool ContainsItem(InventoryItem item)
    {
        if (item == null) return false;
        else if (residentObject != null)
        {
            if (residentObject.GetComponent<ItemStack>() != null)
                return residentObject.GetComponent<ItemStack>().ContainsItem(item);
            else if (residentObject.GetComponent<VariableHolder>() != null)
                return residentObject.GetComponent<VariableHolder>().ContainsItem(item);
            else return false;
        }
        else return false;
    }

    /*
    public void PrintBox()
    {
        if (residentObject != null) residentObject.GetComponent<ItemStack>().PrintStack();
    }
    */
}
