using UnityEngine;
using System.Collections;

// gotta be a way to make start_stop less confusing

public class TimerEvent : InteractionEvent
{
    public bool set;
    public bool start_stop;
    public bool hide;
    public bool addPoints;
    public int min, sec;

    public TimerEvent()
    {
        character = Character.Player;
        start_stop = false;
        set = false;
        min = sec = 0;
    }

    public TimerEvent(Character c, bool set_timer, bool start_or_stop, bool hide_timer, bool add_points, int minutes, int seconds)
    {
        character = c;
        start_stop = start_or_stop;
        hide = hide_timer;
        set = set_timer;
        addPoints = add_points;
        min = minutes;
        sec = seconds;
    }
}
