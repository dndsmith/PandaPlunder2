using UnityEngine;
using System.Collections;

// Event object for gems
// TODO: overload equals operator

public class GemEvent : InteractionEvent
{
    public bool pickup;
    public bool drop;

    public int points;

    public GemEvent()
    {
        character = Character.Player;
        inProximity = false;
        pickup = false;
        drop = false;
        points = 0;
    }

    public GemEvent(Character c, bool in_proximity, bool pick_up_gem, bool drop_gem, int pts_gained)
    {
        character = c;
        inProximity = in_proximity;
        pickup = pick_up_gem;
        drop = drop_gem;
        points = pts_gained;
    }
}
