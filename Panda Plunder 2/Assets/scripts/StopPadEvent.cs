﻿using UnityEngine;
using System.Collections;

public class StopPadEvent : InteractionEvent
{
    public StopPadEvent()
    {
        character = Character.Player;
        inProximity = false;
    }

    public StopPadEvent(Character c, bool in_proximity)
    {
        character = c;
        inProximity = in_proximity;
    }
}