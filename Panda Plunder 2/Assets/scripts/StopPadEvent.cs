using UnityEngine;
using System.Collections;

// Game 2

/*
*  Event data sent to a StopPadInteractable.
*/

public class StopPadEvent : InteractableEvent
{
    public StopPadEvent()
    {
        character = Character.Player;
        inProximity = false;
    }

    public StopPadEvent(Character c, bool in_proximity)
    {
        character = c;
        inProximity = in_proximity;
    }
}
