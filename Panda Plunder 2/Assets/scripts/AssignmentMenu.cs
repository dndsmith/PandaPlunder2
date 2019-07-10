using UnityEngine;
using System.Collections.Generic;
using System;

public class AssignmentMenu : MonoBehaviour
{
    public event EventHandler<EventArgs> MenuClosed; // event fires when the menu is closed

    private Inventory inventory;
    private moveScore[] moves;
    private Variable variable;
    private ChangeButtonImage[] addSubtractButtons;
    private bool isDisplayed;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        moves = GetComponents<moveScore>();
        addSubtractButtons = GetComponentsInChildren<ChangeButtonImage>();
    }

    private void Start()
    {
        CloseMenu();
    }

    public void DisplayMenu()
    {
        moves[0].toView = isDisplayed = true;
    }

    public void CloseMenu()
    {
        if (isDisplayed) // don't remove this. It prevents stack overflow
        {
            moves[0].toView = isDisplayed = false;
            variable = null; // clear variable
            EventArgs e = new EventArgs();
            OnMenuClosed(e);
        }
    }

    public void SetVariable(Variable V)
    {
        variable = V;
    }

    // is definitely dependent on order
    public void AssignVariable()
    {
        if (variable == null) return;
        List<InventoryItem> intermediateValue = new List<InventoryItem>();
        List<InventoryItem> bufferForNegatives = new List<InventoryItem>();
        string itemType = "";

        // check for assignment of different types
        for(int i = 0; i < inventory.inventoryBoxes.Length; i++)
        {
            if (itemType == "" && inventory.inventoryBoxes[i].GetItemType() != null)
                itemType = inventory.inventoryBoxes[i].GetItemType();
            else if(inventory.inventoryBoxes[i].GetItemType() != null)
            {
                if(!itemType.Equals(inventory.inventoryBoxes[i].GetItemType()))
                {
                    Debug.Log("Assignment of different types!");
                    return;
                }
            }
        }

        // check for nothing in any of the boxes
        if(itemType == "")
        {
            Debug.Log("Empty assignment. Did you mean to do that?");
            return;
        }

        for(int i = 0; i < inventory.inventoryBoxes.Length; i++)
        {
            //boxes.inventoryBoxes[i].PrintBox(); DEBUGGING
            InventoryItem[] itemsInBox = inventory.inventoryBoxes[i].RemoveAllItems();
            int j = 0;
            if (itemsInBox == null) continue;
            else if(i == 0 || addSubtractButtons[i-1].isIncumbent) // add
            {
                for(; bufferForNegatives.Count != 0 && j < itemsInBox.Length; j++)
                    bufferForNegatives.RemoveAt(0);
                for(; j < itemsInBox.Length; j++)
                    intermediateValue.Add(itemsInBox[j]);
            }
            else // subtract
            {
                for(; intermediateValue.Count != 0 && j < itemsInBox.Length; j++)
                    intermediateValue.RemoveAt(0);
                for (; j < itemsInBox.Length; j++)
                    bufferForNegatives.Add(itemsInBox[j]);
            }
        }

        variable.Assign(intermediateValue);
        //if (bufferForNegatives.Count != 0) Debug.Log($"negative assignment value is {bufferForNegatives.Count}");
        CloseMenu();
    }

    protected virtual void OnMenuClosed(EventArgs e)
    {
        MenuClosed?.Invoke(this, e);
    }
}