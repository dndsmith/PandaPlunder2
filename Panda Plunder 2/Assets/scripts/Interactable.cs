using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Game 2

/* 
 * Represents an object that the player (i.e. raccoon) can interact with.
 * Specific objects with which the player can interact must implement this class.
 * 
 * Another way of thinking about this class is that it is an event listener for events
 * from the player, where the player is an event source. It's event-driven programming.
 * 
 * To implement a new interactable, one must do 3 things:
 * 1) Create a class that implements Interactable
 * 2) Create a separate class that implements InteractableEvent
 * 3) Add logic in PlayerController for how the player interacts with it
 * 
 * @invariant - only ONE Interactable component per GameObject.
 */

public abstract class Interactable : MonoBehaviour
{
    protected PlayerController player;
    protected SparkleControl sparkle;

    public Image prompt;
    public Camera cam;

    private void Awake()
    {
        // get player object, add listener
        player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.AddInteractable(this);

        // get sparkle object, add listener
        // Since Sparkle isn't being used right now, it's not important
        sparkle = FindObjectOfType<SparkleControl>();
        if (sparkle != null)
            sparkle.AddInteractable(this);

        if (prompt != null) prompt.enabled = false;
    }

    public abstract void ReceiveEvent(InteractableEvent e);
    protected abstract void InProximityReaction();
    protected abstract void OutOfProximityReaction();
    protected virtual void ShowPrompt()
    {
        if (prompt != null)
        {
            prompt.enabled = true;
            prompt.rectTransform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 0, 1));
        }
    }

    protected void HidePrompt()
    {
        if (prompt != null) prompt.enabled = false;
    }
    protected virtual void OnDestroy() => HidePrompt(); // ooh, fancy arrow thang
}
