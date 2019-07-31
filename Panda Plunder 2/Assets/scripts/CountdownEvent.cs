using UnityEngine;
using System.Collections;

// Game 2
// NOT USED

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
