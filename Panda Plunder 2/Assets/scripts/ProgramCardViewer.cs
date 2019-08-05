using UnityEngine;
using UnityEngine.UI;
using System;

// Game 2

/*
 *  Controls the image that displays a program card to the player.
 *  That is, when the player interacts with the program card, this "viewer" moves the card
 *  into the middle of the screen so the player can read it.
 */

public class ProgramCardViewer : MonoBehaviour
{
    public moveCharacter MC;
    public event EventHandler<HideProgramCardEventArgs> HideProgramCard;

    private moveScore MS;
    private ProgramCardInteractable PCI;
    private bool beingViewed;

    private void Start()
    {
        MS = GetComponent<moveScore>();
        PCI = null;
        HideCard();
    }

    public void ShowCard(ProgramCardInteractable programCard)
    {
        MS.toView = beingViewed = true;
        MC.enabled = false;
        PCI = programCard;
    }

    public void HideCard()
    {
        MS.toView = beingViewed = false;
        MC.enabled = true;
        HideProgramCardEventArgs e = new HideProgramCardEventArgs
        {
            programCard = PCI
        };
        OnHidePogramCard(e);
    }
    
    public void HideCard(ProgramCardInteractable programCard)
    {
        MS.toView = beingViewed = false;
        MC.enabled = true;
        HideProgramCardEventArgs e = new HideProgramCardEventArgs
        {
            programCard = programCard
        };
        OnHidePogramCard(e);
    }

    public void ChangeCard(Sprite cardSprite)
    {
        MS.gameObject.GetComponent<Image>().sprite = cardSprite;
    }

    public bool IsBeingViewed()
    {
        return beingViewed;
    }

    protected virtual void OnHidePogramCard(HideProgramCardEventArgs e)
    {
        HideProgramCard?.Invoke(this, e);
    }
}
