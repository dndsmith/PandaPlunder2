using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1

public class QDoorControl : MonoBehaviour {

    public Material glowMat;

    public void startGlow()
    {

        glowMat.SetFloat("_EmissionAmp", 1f);

    }

}
