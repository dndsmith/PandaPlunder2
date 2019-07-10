using UnityEngine;
using System.Collections;

public class ProgramCardEvent : InteractionEvent
{
    public bool viewCard;

    public ProgramCardEvent()
    {
        character = Character.Player;
        inProximity = false;
    }

    public ProgramCardEvent(Character c, bool in_proximity, bool view_card)
    {
        character = c;
        inProximity = in_proximity;
        viewCard = view_card;
    }
}
