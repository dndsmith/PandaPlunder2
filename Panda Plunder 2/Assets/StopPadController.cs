﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// EVENT SOURCE AND LISTENER

// NEED a better name
// RENAME DoSomething function?

public class StopPadController : Interactable
{
    public Texture stopColor;  // usually  red  color
    public Texture startColor; // usually green color

    private Renderer m_renderer;

    private AssignmentActivity assignmentActivity;
    private bool gameStarted = false;

    private void Start()
    {
        assignmentActivity = GetComponentInParent<AssignmentActivity>();
        m_renderer = GetComponent<Renderer>();
        m_renderer.material.SetTexture("_MainTex", startColor);
    }

    public override void ReceiveEvent(InteractableEvent e)
    {
        if (!e.GetType().Equals(typeof(StopPadEvent)))
        {
            // I've got Lackadaisycathro Disease!
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
        if(gameStarted) // stop the game
        {
            m_renderer.material.SetTexture("_MainTex", startColor); // usually green color
            assignmentActivity.StopActivity();
        }
        else // start the game
        {
            m_renderer.material.SetTexture("_MainTex", stopColor); // usually red color
            assignmentActivity.StartActivity();

        }
        gameStarted = !gameStarted;
    }

    protected override void OutOfProximityReaction()
    {
        // nothing to do here
    }
}
