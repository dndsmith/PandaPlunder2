using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1

/*
 *  I think this controls the black screen that clears at the start of a level and covers at the end of a level.
 */

public class wipeControl : MonoBehaviour {

    public int waitTimer;
    public moveScore MS;
    public bool direction = true;
 
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame

    public void wipe()
    {

        MS.toView = !MS.toView;

    }
}
