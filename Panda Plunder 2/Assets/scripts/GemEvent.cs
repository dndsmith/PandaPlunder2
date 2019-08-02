using UnityEngine;
using System.Collections;

// Game 2

/*
*  Event data sent to a FourCornersInteractable.
*/

public class GemEvent : InteractableEvent
{
    public bool pickup;
    public bool drop;

    public int points;

    public GemEvent()
    {
        character = Character.Player;
        inProximity = false;
        inTriggerStay = false;
        pickup = false;
        drop = false;
        points = 0;
    }

    public GemEvent(Character c, bool in_proximity, bool in_trigger_stay, bool pick_up_gem, bool drop_gem, int pts_gained)
    {
        character = c;
        inProximity = in_proximity;
        inTriggerStay = in_trigger_stay;
        pickup = pick_up_gem;
        drop = drop_gem;
        points = pts_gained;
    }
}
