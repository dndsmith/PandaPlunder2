using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1

/*
 *  Caused the boss question door to glow in Game 1.
 */

// TODO: remove Animator

public class MakeGlow : MonoBehaviour
{
    public ExitDoor ED;
    private float emissionAmplitude = 1f;

    // once entered, door begins to glow
    private void OnTriggerEnter(Collider other)
    {
        ED.setGlow(emissionAmplitude);
    }
}
