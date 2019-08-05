using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1

/*
 *  I'm not sure if this was ever used, but it seems useful for destorying a GameObject after a certain number of frames.
 */

public class timedDelete : MonoBehaviour {

    public int timer = 10;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        if(timer > 0)
        {

            timer--;

        }
        else
        {

            GameObject.Destroy(transform.gameObject);

        }
		
	}
}
