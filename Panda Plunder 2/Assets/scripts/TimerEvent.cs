using UnityEngine;
using System.Collections;

// Game 2

/*
*  Event data sent to a TimerController.
*/

public class TimerEvent : InteractableEvent
{
    public bool set;
    public bool start_stop;
    public bool hide;
    public int min, sec;

    public TimerEvent()
    {
        character = Character.Player;
        start_stop = false;
        set = false;
        min = sec = 0;
    }

    public TimerEvent(Character c, bool set_timer, bool start_or_stop, bool hide_timer, int minutes, int seconds)
    {
        character = c;
        start_stop = start_or_stop;
        hide = hide_timer;
        set = set_timer;
        min = minutes;
        sec = seconds;
    }
}
