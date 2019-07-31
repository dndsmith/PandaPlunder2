using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Game 2

public class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DragItem residentItem = null; //fix accessibility
    public InventoryBox box; //fix accessibility

    private void Awake()
    {
        box = GetComponentInChildren<InventoryBox>(); // in children just to be safe
    }

    public bool SameType(ItemStack stack)
    {
        // true if residentItem has an ItemStack, the object being dragged has an ItemStack, and these two stacks are of the same type
        // false otherwise
        if (residentItem == null) return false;
        else return residentItem.gameObject.GetComponent<ItemStack>() != null && stack != null && residentItem.gameObject.GetComponent<ItemStack>().GetItemType().Equals(stack.GetItemType());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        DragItem d = eventData.pointerDrag.GetComponent<DragItem>();
        if (d != null && residentItem == null)
        {
            d.InDropZone(true);
        }
        else if(d != null && SameType(d.gameObject.GetComponent<ItemStack>()))
        {
            d.DropInZone(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragItem d = eventData.pointerDrag.GetComponent<DragItem>();
        if (d != null && residentItem == null)
        {
            d.InDropZone(false);
        }
    }

    public void SetResidentItem(DragItem DI)
    {
        residentItem = DI;
        if (box != null)
        {
            if (DI == null) box.SetResident(null);
            else box.SetResident(DI.gameObject);
        }
    }

    public bool HasResident()
    {
        return residentItem != null;
    }

    public void DestroyResident()
    {
        Destroy(residentItem.gameObject);
    }

    public void AddItems(InventoryItem[] items)
    {
        ItemStack itemStack = residentItem.gameObject.GetComponent<ItemStack>();
        if(itemStack != null)
        {
            itemStack.AddItems(items);
        }
    }

    public bool IsInventoryBox()
    {
        return box != null;
    }
}
