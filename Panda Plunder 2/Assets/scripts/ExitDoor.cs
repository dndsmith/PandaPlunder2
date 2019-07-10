using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {


    public Material glowMat;

    private void Start()
    {
        setGlow(0f);
    }

    public void setGlow(float g)
    {

        glowMat.SetFloat("_EmissionAmp", g);

    }

    public void doorOpen()
    {
        Destroy(transform.gameObject);


    }


}
