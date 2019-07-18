using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TRY LOWERING LIGHTS?

public class ProgramCardInteractable : Interactable
{
    // boolean states
    private bool isBeingViewed = false;

    public moveScore MS;
    public Sprite programCard;
    public moveCharacter MC;
    public GameObject barrier;

    private void Start()
    {
        MS.toView = false;
    }

    public override void ReceiveEvent(InteractableEvent e)
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
            else if (pce.inProximity && !isBeingViewed) InProximityReaction();
            else if (pce.inTriggerStay && !isBeingViewed) ShowPrompt();
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
        MS.gameObject.GetComponent<Image>().sprite = programCard;
        HidePrompt();
        MS.toView = isBeingViewed = true;
        MC.enabled = false;
    }

    private void HideCard()
    {
        if (!isBeingViewed) return;
        MS.toView = isBeingViewed = false;
        MC.enabled = true;
        if (barrier != null) Destroy(barrier);
    }

    public void PlayerExitedCardGUI()
    {
        HideCard();
    }
}
