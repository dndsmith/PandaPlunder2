using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// The "drop zone" for ItemStacks
// I have been informed that returning null collections is bad practice...oh well
// FIXME: refactor so that methods return empty array/list

public class InventoryBox : MonoBehaviour
{
    public GameObject itemStackPrefab;
    public GameObject residentObject = null; // fix accessibility
    public DropZone DZ; // fix acessibility

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
            else if (residentObject.GetComponent<Variable>() != null)
                return residentObject.GetComponent<Variable>().GetValue();
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
            else if (residentObject.GetComponent<Variable>() != null)
                return residentObject.GetComponent<Variable>().GetValue();
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
        residentObject = Instantiate(itemStackPrefab, this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        residentObject.GetComponent<DragItem>().SetHomeBase(DZ);
        DZ.SetResidentItem(residentObject.GetComponent<DragItem>());
    }

    public string GetItemType()
    {
        if (residentObject != null)
        {
            if (residentObject.GetComponent<ItemStack>() != null)
                return residentObject.GetComponent<ItemStack>().GetItemType();
            else if (residentObject.GetComponent<Variable>() != null)
                return residentObject.GetComponent<Variable>().GetItemType();
            else return null;
        }
        else return null;
    }

    /*
    public void PrintBox()
    {
        if (residentObject != null) residentObject.GetComponent<ItemStack>().PrintStack();
    }
    */
}
