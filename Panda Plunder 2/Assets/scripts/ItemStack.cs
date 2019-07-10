using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemStack : MonoBehaviour
{
    private Image itemImage;
    private Text textCount;
    private RectTransform textRT;
    //private bool initialization = true;

    Stack<InventoryItem> stack = new Stack<InventoryItem>();

    private void Awake()
    {
        itemImage = GetComponent<Image>();
        textCount = GetComponentInChildren<Text>();
        if (textCount != null)
        {
            textRT = textCount.gameObject.GetComponent<RectTransform>();
            textCount.enabled = false;
        }
    }

    private void Update()
    {
        if(stack.Count < 1)
        {
            Destroy(this.gameObject); // should make it so InventoryBox has null for residentStack as well as DropZone
        }
        else if (textCount != null)
        {
            if (stack.Count > 1)
            {
                textCount.enabled = true;
                textCount.text = stack.Count.ToString();
                textCount.fontSize = Mathf.FloorToInt(textRT.rect.height); // DragItem takes care of size of text box
            }
            else
                textCount.enabled = false;
        }
    }

    // adds an InventoryItem to the stack
    // returns true if successful, false otherwise
    public bool AddItem(InventoryItemComponent item)
    {
        if (item == null) return false;
        InventoryItem copy = new InventoryItem(item);
        if (stack.Count == 0)
        {
            stack.Push(copy);
            itemImage.sprite = copy.icon;
            return true;
        }
        else
        {
            if (stack.Count == 99) return false;
            else
            {
                if (copy.type.Equals(stack.Peek().type))
                {
                    stack.Push(copy);
                    return true;
                }
                else return false;
            }
        }
    }

    // overload for InventoryItem insertion
    public bool AddItem(InventoryItem item)
    {
        if (item == null) return false;
        if (stack.Count == 0)
        {
            stack.Push(item);
            itemImage.sprite = item.icon;
            return true;
        }
        else
        {
            if (stack.Count == 99) return false;
            else
            {
                if (item.type.Equals(stack.Peek().type))
                {
                    stack.Push(item);
                    return true;
                }
                else return false;
            }
        }
    }

    public bool AddItems(InventoryItemComponent[] items)
    {
        if (items == null) return false;
        bool success = true;
        foreach (InventoryItemComponent item in items)
        {
            success &= AddItem(item);
        }
        return success;
    }

    public bool AddItems(InventoryItem[] items)
    {
        if (items == null) return false;
        bool success = true;
        foreach (InventoryItem item in items)
        {
            success &= AddItem(item);
        }
        return success;
    }

    // removes an iten from the stack and returns it
    // returns null if the stack is empty
    public InventoryItem RemoveItem()
    {
        if (stack.Count == 0) return null;
        else return stack.Pop();
    }

    // removes a certain number of items (count) from the stack
    public InventoryItem[] RemoveItems(int count)
    {
        if (stack.Count == 0 || count <= 0) return null;
        else
        {
            InventoryItem[] items = new InventoryItem[count];
            for (int i = 0; i < count; i++)
                items[i] = RemoveItem();
            return items;
        }
    }

    public InventoryItem[] RemoveAllItems()
    {
        return RemoveItems(stack.Count);
    }

    public int GetCount()
    {
        return stack.Count;
    }

    public InventoryItem Peek()
    {
        if (stack.Count != 0) return stack.Peek();
        else return null;
    }

    public string GetItemType()
    {
        if (stack.Count != 0) return stack.Peek().type;
        else return null;
    }

    public void PrintStack()
    {
        foreach(InventoryItem item in stack)
        {
            item.PrintItem();
        }
    }
}
