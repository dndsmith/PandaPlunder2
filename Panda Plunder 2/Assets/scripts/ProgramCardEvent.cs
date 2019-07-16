using UnityEngine;
using System.Collections;

public class ProgramCardEvent : InteractableEvent
{
    public bool viewCard;

    public ProgramCardEvent()
    {
        character = Character.Player;
        inProximity = false;
        inTriggerStay = false;
    }

    public ProgramCardEvent(Character c, bool in_proximity, bool in_trigger_stay, bool view_card)
    {
        character = c;
        inProximity = in_proximity;
        inTriggerStay = in_trigger_stay;
        viewCard = view_card;
    }
}
