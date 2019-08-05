using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2

/*
 *  Controls interactions between the player and the Four Corners pad.
 *  Contains logic to start the Four Corners pad and turn its lights on/off, and 
 *  
 *  Until I can find a way to fix the lights, they are commented out
 */

public class FourCornersInteractable : Interactable
{
    // Lights are in order Red, Yellow, Green, Blue
    // ................(forward, left, right, backward)
    //private Light [] colorLights;
    private bool[] highBeams = new bool[4];

    private BoxCollider[] colliders;
    private FlashCardActivity flashCardActivity;
    private bool gameStarted;

    void Start()
    {
        //colorLights = GetComponentsInChildren<Light>();
        flashCardActivity = GetComponentInParent<FlashCardActivity>();
        colliders = GetComponentsInChildren<BoxCollider>();
        DisableLights();
    }

    public override void ReceiveEvent(InteractableEvent e)
    {
        if(!e.GetType().Equals(typeof(FourCornersEvent)))
        {
            // nada
        }
        else
        {
            FourCornersEvent fce = (FourCornersEvent)e;
            if (fce.inProximity && !gameStarted) InProximityReaction();
            if (fce.start && !gameStarted) BeginFourCorners();
            else if (fce.inTriggerStay && !gameStarted) ShowPrompt();
            else OutOfProximityReaction();
        }
    }

    protected override void InProximityReaction()
    {
        ShowPrompt();
    }

    protected override void OutOfProximityReaction()
    {
        HidePrompt();
    }

    public void BeginFourCorners()
    {
        EnableLights();
        foreach (BoxCollider bc in colliders)
        {
            bc.enabled = true;
        }
        gameStarted = true;
        flashCardActivity.StartActivity();
        HidePrompt();
    }

    // what if we did a coroutine so the lights come on one at a time?
    public void EnableLights()
    {
        /*foreach (Light light in colorLights)
        {
            light.enabled = true;
        }*/
    }

    public void DisableLights()
    {
        DisableOneLight("red");
        DisableOneLight("yellow");
        DisableOneLight("green");
        DisableOneLight("blue");
        for (int i = 1; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
        if (gameStarted) flashCardActivity.StopActivity();
    }

    public void EnableOneLight(string color)
    {
        /*color = color.ToLower();
        if (color == "red" && !colorLights[0].enabled)
        {
            colorLights[0].enabled = true;
        }
        else if (color == "yellow" && !colorLights[1].enabled)
        {
            colorLights[1].enabled = true;
        }
        else if (color == "green" && !colorLights[2].enabled)
        {
            colorLights[2].enabled = true;
        }
        else if (color == "blue" && !colorLights[3].enabled)
        {
            colorLights[3].enabled = true;
        }
        else
        {
            Debug.Log("MISSPELLED color of light to enable: " + color + ". Or " + color + " is already on");
        }*/
    }

    public void DisableOneLight(string color)
    {
        /*color = color.ToLower();
        if (color == "red")
        {
            TurnOffHighBeam(color);
            colorLights[0].enabled = false;
        }
        else if (color == "yellow")
        {
            TurnOffHighBeam(color);
            colorLights[1].enabled = false;
        }
        else if (color == "green")
        {
            TurnOffHighBeam(color);
            colorLights[2].enabled = false;
        }
        else if (color == "blue")
        {
            TurnOffHighBeam(color);
            colorLights[3].enabled = false;
        }
        else
        {
            Debug.Log("MISSPELLED color of light to disable: " + color);
        }*/
    }

    // Exaggerate a light (e.g. if walk in direction of the light, make it brighter)
    // IDEA: could return bool if more than one light on highBeam
    // IDEA: coroutine to steadily gradually
    public void TurnOnHighBeam(string color)
    {
        int count = 0;
        color = color.ToLower();
        if(color == "red" && !highBeams[0])
        {
            //colorLights[0].intensity = 1500f;
            //colorLights[0].range = 20f;
            highBeams[0] = true;
        }
        else if(color == "yellow" && !highBeams[1])
        {
            //colorLights[1].intensity = 1500f;
            //colorLights[1].range = 20f;
            highBeams[1] = true;
        }
        else if (color == "green" && !highBeams[2])
        {
            //colorLights[2].intensity = 1500f;
            //colorLights[2].range = 20f;
            highBeams[2] = true;
        }
        else if (color == "blue" && !highBeams[3])
        {
            //colorLights[3].intensity = 1500f;
            //colorLights[3].range = 20f;
            highBeams[3] = true;
        }
        else
        {
            Debug.Log("MISSPELLED color of light to intensify: " + color + ". Or " + color + " is already on high beam");
        }

        for(int i = 0; i < 4; i++)
        {
            if (highBeams[i]) count++;
        }

        if(count > 1)
        {
            Debug.Log("WARNING more than one highBeam on");
        }
    }

    // Turn off a highBeam (make it less bright)
    public void TurnOffHighBeam(string color)
    {
        color = color.ToLower();
        if (color == "red")
        {
            //colorLights[0].intensity = 5f;
            //colorLights[0].range = 3f;
            highBeams[0] = false;
        }
        else if (color == "yellow")
        {
            //colorLights[1].intensity = 5f;
            //colorLights[1].range = 3f;
            highBeams[1] = false;
        }
        else if (color == "green")
        {
            //colorLights[2].intensity = 5f;
            //colorLights[2].range = 3f;
            highBeams[2] = false;
        }
        else if (color == "blue")
        {
            //colorLights[3].intensity = 5f;
            //colorLights[3].range = 3f;
            highBeams[3] = false;
        }
        else
        {
            Debug.Log("MISSPELLED color of light to dampen: " + color);
        }
    }

    public bool IsOnHigh(string color)
    {
        color = color.ToLower();
        if (color == "red")
        {
            return highBeams[0];
        }
        else if (color == "yellow")
        {
            return highBeams[1];
        }
        else if (color == "green")
        {
            return highBeams[2];
        }
        else if (color == "blue")
        {
            return highBeams[3];
        }
        else
        {
            Debug.Log("MISSPELLED color of light to check: " + color);
            return false;
        }
    }
}
