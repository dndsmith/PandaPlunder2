using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLogoControl : MonoBehaviour {

    public moveScore MS;
    public int timer = 400;
    public AudioSource shot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(timer > 0)
        {

            timer--;
            if(timer == 75)
            {

                shot.Play();

            }

        }
        else
        {

            MS.toView = false;
            this.enabled = false;

        }

		
	}
}
