using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class AssignmentMenu : MonoBehaviour
{
    public event EventHandler<EventArgs> MenuOpened; // event fires when the menu is opened
    public event EventHandler<EventArgs> MenuClosed; // event fires when the menu is closed

    public Text variableName;

    private Inventory inventory;
    private moveScore[] moves;
    private Variable variable;
    private ChangeImage[] addSubtractButtons;
    private bool isDisplayed;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        moves = GetComponents<moveScore>();
        addSubtractButtons = GetComponentsInChildren<ChangeImage>();
    }

    private void Start()
    {
        CloseMenu();
    }

    public void DisplayMenu()
    {
        moves[0].toView = isDisplayed = true;
        EventArgs e = new EventArgs();
        OnMenuOpened(e);
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
        variableName.text = variable.varName;
        GetComponentsInChildren<Image>()[1].sprite = variable.varIcon;
    }

    // is definitely dependent on order
    public void AssignVariable()
    {
        if (variable == null) return;
        List<InventoryItem> intermediateValue = new List<InventoryItem>();
        List<InventoryItem> bufferForNegatives = new List<InventoryItem>();
        string itemType = null;

        // check for assignment of different types
        for(int i = 0; i < inventory.inventoryBoxes.Length; i++)
        {
            if (itemType == null && inventory.inventoryBoxes[i].GetItemType() != null)
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
        if(itemType == null)
        {
            MessagePanelController.DisplayMessage("Empty assignment!", 2.0f);
            return;
        }

        for(int i = 0; i < inventory.inventoryBoxes.Length; i++)
        {
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
            inventory.inventoryBoxes[i].DestroyContents();
        }

        variable.Assign(intermediateValue);
        //if (bufferForNegatives.Count != 0) Debug.Log($"negative assignment value is {bufferForNegatives.Count}");
        CloseMenu();
    }

    protected virtual void OnMenuClosed(EventArgs e)
    {
        MenuClosed?.Invoke(this, e);
    }

    protected virtual void OnMenuOpened(EventArgs e)
    {
        MenuOpened?.Invoke(this, e);
    }
}