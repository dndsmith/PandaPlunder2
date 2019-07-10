using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// EVENT SOURCE AND LISTENER

// NEED a better name
// RENAME DoSomething function?

public class StopPadController : Interactable
{
    public Texture stopMaterial;  // usually  red  color
    public Texture startMaterial; // usually green color
    public int minutesForTimer;
    public int secondsForTimer;
    public List<ChestInteractable> chests;
    public CountdownInteractable CDI;

    private Renderer m_renderer;
    private Stopwatch stopWatch;
    private TimerController TC;
    private bool isOnPad;
    private bool gameStarted;

    private void Start()
    {
        TC = FindObjectOfType<TimerController>();
        stopWatch = new Stopwatch();
        isOnPad = gameStarted = false;
        m_renderer = GetComponent<Renderer>();
        m_renderer.material.SetTexture("_MainTex", startMaterial);
    }

    public override void ReceiveEvent(InteractionEvent e)
    {
        if (!e.GetType().Equals(typeof(StopPadEvent)))
        {
            // I've got Lackadaisycathro Disease
        }
        else
        {
            StopPadEvent spe = (StopPadEvent)e;
            if (spe.inProximity) InProximityReaction();
            else OutOfProximityReaction();
        }
    }

    protected override void InProximityReaction()
    {
        isOnPad = true;
        stopWatch.Reset();
        StartCoroutine(SwitchActivity());
    }

    protected override void OutOfProximityReaction()
    {
        isOnPad = false;
    }

    private void DoSomething()
    {
        gameStarted = !gameStarted;
        if (gameStarted)
        {
            TC.ReceiveEvent(new TimerEvent(InteractionEvent.Character.Player, true, true, false, false, minutesForTimer, secondsForTimer));
            m_renderer.material.SetTexture("_MainTex", stopMaterial); // usually red color
        }
        else
        {
            m_renderer.material.SetTexture("_MainTex", startMaterial); // usually green color
            StartCoroutine(TimeOut());
        }
    }

    IEnumerator SwitchActivity()
    {
        int time;
        if (!gameStarted)
        {
            CDI.ReceiveEvent(new CountdownEvent(true));
            time = 3;
        }
        else
        {
            TC.ReceiveEvent(new TimerEvent(InteractionEvent.Character.Player, false, true, false, false, 0, 0));
            time = 2;
        }
        stopWatch.Start();
        while(stopWatch.Elapsed.Seconds < time && isOnPad)
        {
            yield return 0;
        }
        stopWatch.Reset();
        if (isOnPad)
        {
            DoSomething();
        }
        else
        {
            CDI.ReceiveEvent(new CountdownEvent(false));
        }
    }

    IEnumerator TimeOut()
    {
        stopWatch.Start();
        while(stopWatch.Elapsed.Seconds < 1)
        {
            yield return 0;
        }
        stopWatch.Reset();
        bool win = true;
        foreach(ChestInteractable c in chests)
        {
            win = win && c.ContentsMatch();
        }
        TC.ReceiveEvent(new TimerEvent(InteractionEvent.Character.Player, false, false, true, win, 0, 0));
    }
}
