using UnityEngine;
using System.Collections;

// Game 2
// NOT USED

public class InventoryEvent : InteractableEvent
{
    public InventoryEvent()
    {
        character = Character.Player;
        inProximity = false;
    }

    public InventoryEvent(Character c, bool in_proximity)
    {
        character = c;
        inProximity = in_proximity;
    }
}
