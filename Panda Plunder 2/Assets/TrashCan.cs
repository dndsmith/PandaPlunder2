using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

/*
 *  Formerly would delete an InventoryItem when dragged onto the trash can.
 */

public class TrashCan : MonoBehaviour
{
    DropZone theZone;
    moveScore theMove;

    private void Start()
    {
        theZone = GetComponent<DropZone>();
        theMove = GetComponent<moveScore>();
        AssignmentMenu theMenu = FindObjectOfType<AssignmentMenu>();
        theMenu.MenuOpened += C_OnAssignmentMenuOpened;
        theMenu.MenuClosed += C_OnAssignmentMenuClosed;
    }

    private void Update()
    {
        if(theZone.HasResident())
        {
            theZone.DestroyResident();
        }
    }

    public void C_OnAssignmentMenuOpened(object sender, System.EventArgs e)
    {
        theMove.toView = true;
    }

    public void C_OnAssignmentMenuClosed(object sender, System.EventArgs e)
    {
        theMove.toView = false;
    }
}
