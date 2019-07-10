using UnityEngine;
using System.Collections;

// gotta be a way to make open_close less confusing

public class ChestEvent : InteractionEvent
{
    public bool open_close_chest;
    public bool deposit_items;
    public bool take_items;
    public bool trigger_stay;

    public ChestEvent()
    {
        open_close_chest = deposit_items = take_items = inProximity = false;
        character = Character.Player;
    }

    public ChestEvent(Character c, bool in_proximity, bool open_OR_close, bool deposit, bool take, bool triggerStay)
    {
        character = c;
        inProximity = in_proximity;
        open_close_chest = open_OR_close;
        deposit_items = deposit;
        take_items = take;
        trigger_stay = triggerStay;
    }
}
