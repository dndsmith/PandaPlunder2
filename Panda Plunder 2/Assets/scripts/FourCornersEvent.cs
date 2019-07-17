using UnityEngine;
using System.Collections;

public class FourCornersEvent : InteractableEvent
{
    public bool start;

    public FourCornersEvent()
    {
        character = Character.Player;
        inProximity = false;
        inTriggerStay = false;
        start = false;
    }

    public FourCornersEvent(Character c, bool in_proximity, bool in_trigger_stay, bool _start)
    {
        character = c;
        inProximity = in_proximity;
        inTriggerStay = in_trigger_stay;
        start = _start;
    }
}
