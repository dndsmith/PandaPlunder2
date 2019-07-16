using UnityEngine;
using System.Collections;

public class CountdownEvent : InteractableEvent
{
    public CountdownEvent()
    {
        character = Character.Player;
        inProximity = false;
    }

    public CountdownEvent(bool start)
    {
        inProximity = start;
    }
}
