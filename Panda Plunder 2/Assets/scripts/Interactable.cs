using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A listener for events from characters
// @invariant - only ONE Interactable component per GameObject. None on children

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
    protected void OnDestroy() => HidePrompt(); // ooh, fancy arrow thang
}
