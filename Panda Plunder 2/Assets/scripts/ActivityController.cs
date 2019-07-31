using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

// Game 2

public abstract class ActivityController : MonoBehaviour
{
    // the timer
    protected TimerController timer;
    public int minutesForTimer;
    public int secondsForTimer;

    // score related stuff
    public GameScore gameScore;
    protected const int correctBonus = 1000;

    // activity has started
    public event EventHandler<EventArgs> ActivityStarted;
    public event EventHandler<EventArgs> ActivityStopped;

    // good job quotes
    protected string[] goodJob =
    {
        "Nice job!",
        "Good work!",
        "You done good",
        "Nailed it",
        "Well done, young padawan",
        "Done well, you have"
    };

    protected string[] incorrectAnswer =
    {
        "Not quite correct!",
        "Close, but not quite right",
        "Better luck next time!",
        "Incorrect!",
        "Ouch! That is incorrect"
    };

    // end level
    protected EndLevel endLevel;

    void Awake()
    {
        timer = FindObjectOfType<TimerController>();
        endLevel = FindObjectOfType<EndLevel>();
    }

    public virtual void StartActivity()
    {
        EventArgs e = new EventArgs();
        OnActivityStarted(e);
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, true, true, false, minutesForTimer, secondsForTimer)); // start timer
    }

    public virtual void StopActivity()
    {
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, true, false, 0, 0)); // stop timer
        EventArgs e = new EventArgs();
        OnActivityStopped(e);
        StartCoroutine(WaitToHideTimer());
    }

    public virtual void DestroyActivity()
    {
        endLevel.ActivityCompleted();
        Destroy(gameObject);
    }

    protected virtual IEnumerator WaitToHideTimer()
    {
        System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        SW.Start();
        while(SW.Elapsed.TotalSeconds < 5) // wait 5 seconds before hiding timer
        {
            yield return 0;
        }
        SW.Stop();
        timer.ReceiveEvent(new TimerEvent(InteractableEvent.Character.Player, false, false, true, 0, 0));
        DestroyActivity();
    }

    protected virtual void OnActivityStarted(EventArgs e)
    {
        ActivityStarted?.Invoke(this, e);
    }

    protected virtual void OnActivityStopped(EventArgs e)
    {
        ActivityStopped?.Invoke(this, e);
    }
}
