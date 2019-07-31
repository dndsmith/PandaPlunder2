using UnityEngine;
using System.Collections;

// Game 2

// Event object for messages between character controllers and interactables

public abstract class InteractableEvent
{
    public enum Character
    {
        Player,
        Sparkle
    }

    public Character character;
    public bool inProximity;
    public bool inTriggerStay;
}
