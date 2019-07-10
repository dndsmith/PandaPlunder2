using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {


    public moveCharacter MC;
    public int waitTimer = 50;
    public moveScore MS;
    public AudioSource RPAS;
    public AudioClip woo;
    public wipeControl WC;


	// Use this for initialization
	void Start () {

        RPAS.clip = woo;
        MC.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(waitTimer > 0)
        {

            waitTimer--;
            if(waitTimer == 10)
            {
                WC.wipe();

            }

        }
        else
        {
            RPAS.Play();
            MC.enabled = true;
            MS.toView = true;
            this.enabled = false;
        }

	}
}
