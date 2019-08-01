using UnityEngine;
using System.Collections;

// Game 2
// NOT USED SO FAR
// Has some bugs

/*
 *  Controls interactions between the player character and a door.
 *  The door can open, close, and show/hide a prompt.
 */

public class DoorInteractable : Interactable
{
    public const float accelerator = 5.0f;

    // boolean state
    private bool isOpen = false;

    // components
    private Rigidbody rb;
    private HingeJoint hj;
    private Vector3 currentPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
        currentPos = new Vector3(0, 0, 0);
    }

    public override void ReceiveEvent(InteractableEvent e)
    {
        if(!e.GetType().Equals(typeof(DoorEvent)))
        {
            // what ya doin' in my house fo'?
        }
        else
        {
            DoorEvent de = (DoorEvent)e;
            if (de.inProximity && de.open_close)
            {
                if (isOpen) CloseDoor();
                else OpenDoor();
            }
            else if (de.inProximity) InProximityReaction();
            else if (de.inTriggerStay) ShowPrompt();
            else OutOfProximityReaction();
        }
    }

    protected override void InProximityReaction()
    {
        ShowPrompt();
    }

    protected override void OutOfProximityReaction()
    {
        HidePrompt();
    }

    private void OpenDoor()
    {
        currentPos.y = hj.limits.max;
        isOpen = true;
    }

    private void CloseDoor()
    {
        currentPos.y = -1 * hj.limits.max;
        isOpen = false;
    }
}
