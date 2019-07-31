using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Game 2

// TRY LOWERING LIGHTS?

public class ProgramCardInteractable : Interactable
{
    public ProgramCardViewer cardViewer;
    public Sprite programCard;

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
                if (cardViewer.IsBeingViewed())
                    HideCard();
                else
                    ShowCard();
            }
            else if (pce.inProximity && !cardViewer.IsBeingViewed()) InProximityReaction();
            else if (pce.inTriggerStay && !cardViewer.IsBeingViewed()) ShowPrompt();
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
        if (cardViewer.IsBeingViewed()) return;
        cardViewer.ChangeCard(programCard);
        HidePrompt();
        cardViewer.ShowCard(this);
    }

    private void HideCard()
    {
        if (!cardViewer.IsBeingViewed()) return;
        cardViewer.HideCard(this);
    }
}
