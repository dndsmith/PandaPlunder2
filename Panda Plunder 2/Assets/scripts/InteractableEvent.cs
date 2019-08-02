using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Contains data about how the player interacted with an Interactable object.
 *  This is sent as an event with all its data to the Interactable.
 *  A new Interactable object must also have a class that implements InteractableEvent.
 *  
 *  To implement a new interactable, one must do 3 things:
 *  1) Create a class that implements Interactable
 *  2) Create a separate class that implements InteractableEvent
 *  3) Add logic in PlayerController for how the player interacts with it
 */

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
