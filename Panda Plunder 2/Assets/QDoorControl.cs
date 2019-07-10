using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QDoorControl : MonoBehaviour {

    public Material glowMat;

    public void startGlow()
    {

        glowMat.SetFloat("_EmissionAmp", 1f);

    }

}
