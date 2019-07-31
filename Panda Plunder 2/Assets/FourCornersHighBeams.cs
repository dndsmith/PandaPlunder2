using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2

public class FourCornersHighBeams : MonoBehaviour
{
    public string color;
    private FourCornersController FCC;

    private void Start()
    {
        FCC = GetComponentInParent<FourCornersController>();
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
