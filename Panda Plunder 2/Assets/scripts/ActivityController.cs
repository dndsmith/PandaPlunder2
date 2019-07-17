using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public abstract class ActivityController : MonoBehaviour
{
    // the timer
    protected TimerController timer;
    public int minutesForTimer;
    public int secondsForTimer;

    // score related stuff
    public GameScore gameScore;
    protected const int correctBonus = 1000;

    // good job quotes
    protected string[] goodJob =
    {
        "Nice job!",
        "Good work!",
        "You done good",
        "Nailed it",
        "Well done, young padawan",
        "Done well, you have",
    };



    void Awake()
    {
        timer = FindObjectOfType<TimerController>();
    }

    public virtual void StartActivity()
    {
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, true, true, false, minutesForTimer, secondsForTimer)); // start timer
    }

    public virtual void StopActivity()
    {
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, true, false, 0, 0)); // stop timer
        StartCoroutine(WaitToHideTimer());
    }

    public virtual void DestroyActivity()
    {
        Destroy(gameObject);
    }

    protected virtual IEnumerator WaitToHideTimer()
    {
        System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        SW.Start();
        while(SW.Elapsed.TotalSeconds < 2) // wait a couple seconds before hiding timer
        {
            yield return 0;
        }
        SW.Stop();
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, false, true, 0, 0));
        DestroyActivity();
    }
}
