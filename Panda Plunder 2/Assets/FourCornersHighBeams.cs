using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2

/*
 *  Used by the box colliders in the Four Corners pad to indicate color the player chose.
 *  Formerly, this was indicated with lights; but not anymore since the lights look bad in the game.
 */

public class FourCornersHighBeams : MonoBehaviour
{
    public string color;
    private FourCornersInteractable FCC;

    private void Start()
    {
        FCC = GetComponentInParent<FourCornersInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FCC.TurnOnHighBeam(color);
    }

    private void OnTriggerExit(Collider other)
    {
        if(FCC.IsOnHigh("red") || FCC.IsOnHigh("yellow") || FCC.IsOnHigh("green") || FCC.IsOnHigh("blue"))
            FCC.DisableLights();
    }
}
