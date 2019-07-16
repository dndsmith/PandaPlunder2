using UnityEngine;
using System.Collections;

public class DoorEvent : InteractableEvent
{
    public bool open_close;

    public DoorEvent()
    {
        character = Character.Player;
        inProximity = false;
        inTriggerStay = false;
        open_close = false;
    }

    public DoorEvent(Character c, bool in_proximity, bool in_trigger_stay, bool open_OR_close)
    {
        character = c;
        inProximity = in_proximity;
        inTriggerStay = in_trigger_stay;
        open_close = open_OR_close;
    }
}
