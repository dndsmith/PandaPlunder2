using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

// EVENT LISTENER
// @ requires prompt Image to not be null

public class ChestInteractable : Interactable
{
    // public objects
    public GameObject toBeSpawned;
    public moveCharacter MC;

    // private objects
    private BoxCollider top;
    private AssignmentMenu assignmentMenu;
    private Variable chestVariable;
    private AssignmentActivity assignmentActivity;

    // vars related to phsical gems in chest
    public string [] gemColors;
    public int [] numGemsPerColor;
    private Dictionary<string, int> chestContents = new Dictionary<string, int>();

    // boolean states
    private bool isOpen = false;

    private void Start()
    {
        assignmentMenu = FindObjectOfType<AssignmentMenu>();
        assignmentMenu.MenuClosed += C_OnMenuClosed;
        chestVariable = GetComponentInChildren<Variable>();
        assignmentActivity = GetComponentInParent<AssignmentActivity>();
        BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider box in colliders)
        {
            if (box.CompareTag("ChestTop")) top = box;
        }
    }

    // when gems fall inside chest
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gem"))
        {
            string color = other.gameObject.GetComponent<GemCarryInteractable>().color;
            if (chestContents.ContainsKey(color))
            {
                chestContents[color]++;
            }
            else
            {
                chestContents[color] = 1;
            }
        }
    }

    // when gems leave chest
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Gem"))
        {
            chestContents[other.gameObject.GetComponent<GemCarryInteractable>().color]--;
        }
    }

    // for physical gems inside chest
    public bool ContentsMatch()
    {
        for(int i = 0; i < gemColors.Length; i++)
        {
            if (!chestContents.ContainsKey(gemColors[i])) return false; // chest doesn't even have a gem of the right color
            if (chestContents[gemColors[i]] != numGemsPerColor[i]) return false; // chest doesn't have the right number of gems for that color
        }
        if (chestContents.Count != gemColors.Length) return false; // chest has more gems than specified (if it had fewer, the previous loop would have accounted for it)
        return true;
    }

    override public void ReceiveEvent(InteractableEvent e)
    {
        if (!e.GetType().Equals(typeof(ChestEvent)))
        {
            // mouse trap. ya roll your dice, ya move your mice. nobody gets hurt
        }
        else
        {
            ChestEvent ce = (ChestEvent)e;
            if (ce.inProximity && ce.open_close_chest /*&& !menuIsOpen*/) // THIS COMMENT TEMPORARY...maybe
            {
                if (isOpen)
                    CloseChest();
                else
                    OpenChest();
            }
            else if (ce.inProximity) InProximityReaction();
            else if (ce.inTriggerStay) ShowPrompt();
            else OutOfProximityReaction();
        }
    }

    override protected void InProximityReaction()
    {
        ShowPrompt();
    }

    override protected void OutOfProximityReaction()
    {
        HidePrompt();
    }

    private void OpenChest()
    {
        HidePrompt();
        assignmentActivity.ShowVariables();
        Animation anim = GetComponentInParent<Animation>();
        anim["ChestAnim"].speed = 3.0f;
        anim.Play("ChestAnim");
        assignmentMenu.SetVariable(chestVariable);
        assignmentMenu.DisplayMenu();
        StartCoroutine(WaitToShowPrompt());
    }

    private void CloseChest()
    {
        assignmentActivity.HideVariables();
        Animation anim = GetComponentInParent<Animation>();
        anim["ChestAnim"].speed = -3.0f;
        anim["ChestAnim"].time = anim["ChestAnim"].length;
        anim.Play("ChestAnim");
        StartCoroutine(WaitToShowPrompt());
        assignmentMenu.CloseMenu();
    }

    override protected void ShowPrompt()
    {
        if(!isOpen)
        {
            prompt.enabled = true;
            prompt.rectTransform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 0, 1));
        }
    }

    IEnumerator WaitToShowPrompt()
    {
        isOpen = !isOpen;
        top.enabled = !top.enabled;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (sw.Elapsed.Seconds < 1)
            yield return 0;
        sw.Stop();
        /*if (isOpen)
        {
            foreach(InventoryItem item in chestVariable.GetValue())
                Instantiate(toBeSpawned, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }*/
    }

    public void C_OnMenuClosed(object sender, System.EventArgs e)
    {
        if(isOpen) CloseChest();
    }
}
