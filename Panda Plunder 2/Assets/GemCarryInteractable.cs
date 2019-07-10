using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* * * TODO
 * 1. Raise height of gem at angle relative to pick-up and then move it to front of raccoon (IEnumerator)
 * 2. Automate assigning the color value for the gem rather than depending on the Unity dev
 * */

public class GemCarryInteractable : Interactable
{
    private Vector3 carryPosition;

    public string color;

    public void Start()
    {
        carryPosition = new Vector3(0f, 1f, 0.8f);
    }

    public override void ReceiveEvent(InteractionEvent e)
    {
        // ignore events that are not GemEvents
        if(!e.GetType().Equals(typeof(GemEvent)))
        {
            // *pulls magic conch shell*
            // "Nothing"
        }
        else
        {
            GemEvent ge = (GemEvent)e;
            if (ge.pickup && ge.inProximity) OnPickUp(ge.character);
            else if (ge.drop && ge.inProximity) OnDrop();
            else if (ge.inProximity) InProximityReaction();
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

    private void OnPickUp(InteractionEvent.Character C)
    {
        GetComponent<Rigidbody>().isKinematic = true; // so object stays in air
        if (C == InteractionEvent.Character.Player)
        {
            transform.parent = player.transform;
            transform.localPosition = carryPosition;
        }
        else
            transform.parent = sparkle.transform;
    }

    private void OnDrop()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false; // so object falls down
    }
}
