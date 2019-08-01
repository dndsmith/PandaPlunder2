using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Event data sent to a ChestInteractable.
 */

public class ChestEvent : InteractableEvent
{
    public bool open_close_chest;

    public ChestEvent()
    {
        open_close_chest = inTriggerStay = inProximity = false;
        character = Character.Player;
    }

    public ChestEvent(Character c, bool in_proximity, bool in_trigger_stay, bool open_OR_close)
    {
        character = c;
        inProximity = in_proximity;
        inTriggerStay = in_trigger_stay;
        open_close_chest = open_OR_close;
    }
}
