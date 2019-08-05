using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Game 2

/*
 *  Starts and stops an activity when the player steps on the stop pad.
 *  From prior conversations, needs a redo into two separate units.
 *  
 *  Might should be renamed.
 */

public class StopPadController : Interactable
{
    public Texture stopColor;  // usually  red  color
    public Texture startColor; // usually green color

    private Renderer m_renderer;

    private AssignmentActivity assignmentActivity;
    private CommandActivity commandActivity;
    private bool gameStarted = false;

    private void Start()
    {
        assignmentActivity = GetComponentInParent<AssignmentActivity>();
        commandActivity = GetComponentInParent<CommandActivity>();
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
            if (assignmentActivity != null) assignmentActivity.StopActivity();
            else if (commandActivity != null) commandActivity.StopActivity();
            else UnityEngine.Debug.Log("null activity in stop pad controller");
        }
        else // start the game
        {
            m_renderer.material.SetTexture("_MainTex", stopColor); // usually red color
            if (assignmentActivity != null) assignmentActivity.StartActivity();
            else if (commandActivity != null) commandActivity.StartActivity();
            else UnityEngine.Debug.Log("null activity in stop pad controller");
        }
        gameStarted = !gameStarted;
    }

    protected override void OutOfProximityReaction()
    {
        // nothing to do here
    }
}
