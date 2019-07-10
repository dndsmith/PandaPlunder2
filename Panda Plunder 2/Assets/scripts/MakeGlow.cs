using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
