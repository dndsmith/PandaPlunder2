using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sackFill : MonoBehaviour {


    public Animator A;
    public int fillFrames;

    void Start()
    {

    }

    public void FixedUpdate()
    {
        if(fillFrames > 0)
        {
            fillFrames--;

            if(fillFrames == 0)
            {

                A.SetFloat("speedMult", 0.0f);

            }

        }

    }

    // Update is called once per frame
    public void fill(int cals)
    {
        A.SetFloat("speedMult", (float)cals / 300f);
        Debug.Log(A.GetFloat("speedMult"));
        fillFrames = 10;
    }
}
