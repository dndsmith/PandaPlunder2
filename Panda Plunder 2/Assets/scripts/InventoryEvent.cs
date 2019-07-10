using UnityEngine;
using System.Collections;

public class InventoryEvent : InteractionEvent
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
