using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class ActivityController : MonoBehaviour
{
    // inventory item stuff
    public InventoryItemComponent[] searchItemsInInventory;
    private List<InventoryItem> searchItems = new List<InventoryItem>();
    private Inventory playerInventory;

    // variables in children and the variables menu
    private Variable[] variables;
    private VariablesMenu variablesMenu;

    // the timer
    private TimerController timer;
    public int minutesForTimer;
    public int secondsForTimer;

    public event EventHandler<EventArgs> ItemsFound;

    void Start()
    {
        variables = GetComponentsInChildren<Variable>();
        variablesMenu = FindObjectOfType<VariablesMenu>();
        timer = FindObjectOfType<TimerController>();
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<Inventory>();
        foreach(InventoryItemComponent comp in searchItemsInInventory)
        {
            searchItems.Add(new InventoryItem(comp));
        }
    }


    public void ShowVariables()
    {
        foreach (Variable v in variables)
            variablesMenu.AddVariable(v);
    }

    public void HideVariables()
    {
        variablesMenu.ClearVariables();
    }

    protected virtual void OnItemsFound(EventArgs e)
    {
        Debug.Log("found");
        ItemsFound?.Invoke(this, e);
    }

    public void ActivityStart()
    {
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, true, true, false, minutesForTimer, secondsForTimer)); // start timer
    }

    public void ActivityStop()
    {
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, true, false, 0, 0)); // stop timer
        if (playerInventory.ContainsItems(searchItems.ToArray()))
        {
            EventArgs e = new EventArgs();
            OnItemsFound(e);
        }
        StartCoroutine(WaitToHideTimer());
    }

    public void DestroyActivity()
    {
        Destroy(gameObject);
    }

    IEnumerator WaitToHideTimer()
    {
        System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        SW.Start();
        while(SW.Elapsed.TotalSeconds < 1) // wait a second before hiding timer
        {
            yield return 0;
        }
        SW.Stop();
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, false, true, 0, 0));
        DestroyActivity();
    }
}
