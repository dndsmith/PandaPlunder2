using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2

/* 
 *  Controls interactions between the player and a gem.
 *  Contains logic to physically pick up or drop the gem, but currently the PlayerController opts to stash the gem instead.
 */

public class GemCarryInteractable : Interactable
{
    private Vector3 carryPosition;

    public string color;

    public void Start()
    {
        carryPosition = new Vector3(0f, 1f, 0.8f);
    }

    public override void ReceiveEvent(InteractableEvent e)
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
            else if (ge.inTriggerStay && prompt != null) ShowPrompt();
            else OutOfProximityReaction();
        }
    }

    override protected void InProximityReaction()
    {
        if (prompt != null) ShowPrompt();
    }

    override protected void OutOfProximityReaction()
    {
        if (prompt != null) HidePrompt();
    }

    protected override void ShowPrompt()
    {
        prompt.enabled = true;
        prompt.rectTransform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 0, 2));
    }

    private void OnPickUp(InteractableEvent.Character C)
    {
        GetComponent<Rigidbody>().isKinematic = true; // so object stays in air
        if (C == InteractableEvent.Character.Player)
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
