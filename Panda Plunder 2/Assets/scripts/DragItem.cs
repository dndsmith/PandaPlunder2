using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Game 2

/*
 *  Makes a 2D GameObject draggable.
 *  - If it is within the boundary of a Drop Zone,
 *    then it will remain there until dragged to another drop zone.
 *  - If it is dragged from its Drop Zone to an area without a Drop Zone
 *    it will return to the Drop Zone it was dragged from.
 *  - If an Item Stack is dragged with a left-click, the entire stack is dragged.
 *  - If an Item Stack is dragged with a right-click, one item from the stack is dragged.
 */

[RequireComponent(typeof(BoxCollider2D))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject instantiationPrefab;
    private RectTransform[] RT;
    private DropZone parentHomeBase;
    public DropZone homeBase; // this must stay public
    private bool inDrag;
    private bool inBoundsOfDropZone;

    private void Awake()
    {
        RT = GetComponentsInChildren<RectTransform>();
    }

    private void Update()
    {
        if (!inDrag && homeBase != null)
        {
            StayAtHomeBase();
        }
        else if (!inDrag && homeBase == null)
        {
            if (this.GetComponent<ItemStack>() != null)
            {
                GoBackToNearestStack();
            }
            else if (GetComponent<VariableHolder>() != null)
            {
                Destroy(this.gameObject); // variables get destroyed if not dropped in drop zone
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && GetComponent<ItemStack>() != null)
        {
            GameObject remainingStack = Instantiate(instantiationPrefab, this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform); // create new stack to stay at homeBase
            int size = this.GetComponent<ItemStack>().GetCount();
            remainingStack.GetComponent<ItemStack>().AddItems(this.GetComponent<ItemStack>().RemoveItems(size - 1)); // add all but one item to stack that stays put so the stack being dragged (*this*) only has one item
            parentHomeBase = homeBase;
            SetHomeBase(null);
            if (parentHomeBase != null) parentHomeBase.SetResidentItem(remainingStack.GetComponent<DragItem>());
            inBoundsOfDropZone = true;
        }
        else if(GetComponent<VariableHolder>() != null && !homeBase.IsInventoryBox())
        {
            GameObject remainingVariable = Instantiate(instantiationPrefab, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            remainingVariable.GetComponent<VariableHolder>().SetVariable(this.GetComponent<VariableHolder>().GetVariable());
            parentHomeBase = homeBase;
            SetHomeBase(null);
            if (parentHomeBase != null) parentHomeBase.SetResidentItem(remainingVariable.GetComponent<DragItem>());
            inBoundsOfDropZone = true;
        }
        inDrag = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        // the following is a workaround because the event system doesn't pick up dragging with a right click...
        // ...it should be handled in the DropZone OnPointerEnter function, but NOOO Unity won't cooperate with my suboptimal drag and drop code
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<DropZone>() != null)
            {
                DropZone DZ = eventData.pointerEnter.GetComponent<DropZone>();
                if (DZ == parentHomeBase) return;
                else if (DZ.SameType(this.GetComponent<ItemStack>())) DropInZone(DZ);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inDrag = false;
        if (inBoundsOfDropZone && eventData.pointerEnter != null)
        {
            DropInZone(eventData.pointerEnter.GetComponent<DropZone>());
        }
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void InsideDropZone(bool b)
    {
        inBoundsOfDropZone = b;
    }

    public void DropInZone(DropZone DZ)
    {
        if (DZ == null) return;
        if (DZ.HasResident() && DZ.SameType(this.GetComponent<ItemStack>())) 
        {
            DZ.AddItems(this.GetComponent<ItemStack>().RemoveAllItems());
        }
        else if(!DZ.HasResident())
        {
            if (homeBase != null) homeBase.SetResidentItem(null);
            SetHomeBase(DZ);
            homeBase.SetResidentItem(this);
            InsideDropZone(false);
        }
    }

    public void SetHomeBase(DropZone DZ)
    {
        homeBase = DZ;
    }

    public void GoBackToNearestStack()
    {
        GameObject playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory");
        playerInventory.GetComponent<Inventory>().Stash(GetComponent<ItemStack>().RemoveAllItems());
    }

    private void StayAtHomeBase()
    {
        transform.position = homeBase.gameObject.transform.position;
        if(homeBase.IsInventoryBox()) RT[0].sizeDelta = new Vector2(Mathf.FloorToInt(0.5f * homeBase.GetComponent<RectTransform>().rect.width), Mathf.FloorToInt(0.5f * homeBase.GetComponent<RectTransform>().rect.height));
        else RT[0].sizeDelta = new Vector2(Mathf.FloorToInt(0.8f * homeBase.GetComponent<RectTransform>().rect.width), Mathf.FloorToInt(0.8f * homeBase.GetComponent<RectTransform>().rect.height));
        if (RT.Length > 1)
        {
            for(int i = 1; i < RT.Length; i++)
            {
                RT[i].sizeDelta = new Vector2(Mathf.FloorToInt(0.8f * RT[0].rect.width), Mathf.FloorToInt(0.5f * RT[0].rect.height)); // size of text is handled in ItemStack
            }
        }
    }
}
