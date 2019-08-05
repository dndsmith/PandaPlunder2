using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

// Game 2

/*
 *  Controls the timer in the top right of the screen.
 *  Functions exactly how you'd expect a timer to work: set, start, stop, reset, display, hide, countdown.
 *  
 *  Might should be a Singleton. May not have to implement Interactable, but it works.
 */

public class TimerController : Interactable
{
    private struct Interval
    {
        public int min, sec, totalSecs;
        public Interval(int m, int s)
        {
            min = m;
            sec = s;
            totalSecs = 60 * m + s;
        }
    }

    public GameScore GS;

    private moveScore MS;
    private Stopwatch stopWatch;
    private Text timerText;
    private Interval interval;
    private bool isStopped = true;

    private void Start()
    {
        MS = GetComponentInParent<moveScore>();
        timerText = GetComponent<Text>();
        stopWatch = new Stopwatch();
        interval = new Interval(0, 0);
    }

    public override void ReceiveEvent(InteractableEvent e)
    {
        if (!e.GetType().Equals(typeof(TimerEvent)))
        {
            // <attack> was not effective
        }
        else
        {
            TimerEvent te = (TimerEvent)e;
            if (te.set) SetTimer(te.min, te.sec);
            if (te.start_stop && isStopped) StartTimer();
            else if (te.start_stop && !isStopped) StopTimer();
            else if (te.hide) HideTimer();
            //else
        }
    }

    protected override void InProximityReaction()
    {
        // blank
    }

    protected override void OutOfProximityReaction()
    {
        // blank the squeakquel
    }

    private void SetTimer(int minutes, int seconds)
    {
        ResetTimer();
        timerText.color = new Color(255, 255, 255, 1);
        interval = new Interval(minutes, seconds);
    }

    private void StartTimer()
    {
        isStopped = false;
        stopWatch.Start();
        StartCoroutine(CountDown());
    }

    private void StopTimer()
    {
        stopWatch.Stop();
        isStopped = true;
    }

    private void ResetTimer()
    {
        stopWatch.Reset();
    }

    private void DisplayTimer(string textToDisplay)
    {
        timerText.text = textToDisplay;
        if (!MS.toView) MS.toView = true;
    }

    private void HideTimer()
    {
        if (!isStopped) StopTimer();
        AddPoints();
        if (MS.toView) MS.toView = false;
    }

    // always 10 * remaining seconds
    private void AddPoints()
    {
        GS.addScore(10 * (interval.totalSecs - (int)stopWatch.Elapsed.TotalSeconds));
    }

    IEnumerator CountDown()
    {
        while(interval.totalSecs >= stopWatch.Elapsed.TotalSeconds)
        {
            if (isStopped) break;
            if (((interval.totalSecs - (int)stopWatch.Elapsed.TotalSeconds) <= 10) && ((interval.totalSecs - (int)stopWatch.Elapsed.TotalSeconds) > 9.5)) timerText.color = new Color(255, 0, 0, 1);
            DisplayTimer(Mathf.FloorToInt((interval.totalSecs - (int)stopWatch.Elapsed.TotalSeconds) / 60).ToString("D2") + ":" + ( (interval.totalSecs - (int)stopWatch.Elapsed.TotalSeconds) % 60).ToString("D2"));
            yield return 0;
        }
        if (!isStopped)
        {
            StopTimer();
            DisplayTimer("00:00");
        }
    }
}
