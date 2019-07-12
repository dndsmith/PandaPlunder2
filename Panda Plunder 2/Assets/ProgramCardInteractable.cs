using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// REMOVE MOVECHARACTER AND GAMEOBJECT
// TRY LOWERING LIGHTS?

public class ProgramCardInteractable : Interactable
{
    // boolean states
    private bool isBeingViewed = false;

    public moveScore MS;
    public RawImage image;
    public Texture2D cardPNG;
    public moveCharacter MC;
    public Collider barrier;

    private void Start()
    {
        MS.toView = false;
        image.texture = cardPNG;
    }

    public override void ReceiveEvent(InteractionEvent e)
    {
        if(!e.GetType().Equals(typeof(ProgramCardEvent)))
        {
            // You're not from here, ARE you?
        }
        else
        {
            ProgramCardEvent pce = (ProgramCardEvent)e;
            if (pce.viewCard)
            {
                if (isBeingViewed)
                    HideCard();
                else
                    ShowCard();
            }
            else if (pce.inProximity) InProximityReaction();
            else OutOfProximityReaction();
        }
    }

    protected override void InProximityReaction()
    {
        ShowPrompt();
    }

    protected override void OutOfProximityReaction()
    {
        HidePrompt();
    }

    private void ShowCard()
    {
        if (isBeingViewed) return;
        HidePrompt();
        MS.toView = isBeingViewed = true;
        MC.enabled = false;
    }

    private void HideCard()
    {
        if (!isBeingViewed) return;
        MS.toView = isBeingViewed = false;
        MC.enabled = true;
        barrier.enabled = false;
    }
}
