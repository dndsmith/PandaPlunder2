﻿using UnityEngine;
using System.Collections;

// Event object for messages between character controllers and interactables

public abstract class InteractionEvent
{
    public enum Character
    {
        Player,
        Sparkle
    }

    public Character character;
    public bool inProximity;
}