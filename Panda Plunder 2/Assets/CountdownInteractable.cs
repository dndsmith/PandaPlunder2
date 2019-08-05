using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

// Game 2

/*
 *  Contains logic to control a 3, 2, 1, Go! countdown in the middle of the screen.
 * 
 *  Designed this with the countdown being a one-time event...gonna have to change that
 */

public class CountdownInteractable : Interactable
{
    private moveScore MS;
    private Text countDownText;
    private Stopwatch SW = new Stopwatch();
    private bool isStopped = true;

    private void Start()
    {
        countDownText = GetComponentInChildren<Text>();
        countDownText.text = "3";
        MS = GetComponentInChildren<moveScore>();
        MS.toView = false;
    }

    public override void ReceiveEvent(InteractableEvent e)
    {
        if (!e.GetType().Equals(typeof(CountdownEvent)))
        {
            // ...
        }
        else
        {
            CountdownEvent ce = (CountdownEvent)e;
            if (ce.inProximity) InProximityReaction();
            else OutOfProximityReaction();
        }
    }

    protected override void InProximityReaction()
    {
        isStopped = false;
        countDownText.text = "3"; // to account for case where countdown is stopped midway e.g. at 1 or 2
        MS.toView = true;
        StartCoroutine(Countdown());
    }

    protected override void OutOfProximityReaction()
    {
        isStopped = true;
    }

    IEnumerator Countdown()
    {
        SW.Start();
        while(SW.Elapsed.TotalMilliseconds < 3200 && !isStopped)
        {
            if (SW.Elapsed.TotalSeconds < 1) countDownText.text = "3";
            else if (SW.Elapsed.TotalSeconds < 2) countDownText.text = "2";
            else if (SW.Elapsed.TotalSeconds < 3) countDownText.text = "1";
            else countDownText.text = "GO!";
            yield return 0;
        }
        SW.Reset();
        MS.toView = false;
    }
}
