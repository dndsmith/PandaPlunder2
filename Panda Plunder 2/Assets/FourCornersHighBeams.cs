﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourCornersHighBeams : MonoBehaviour
{
    public string color;
    public FourCornersController FCC;

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