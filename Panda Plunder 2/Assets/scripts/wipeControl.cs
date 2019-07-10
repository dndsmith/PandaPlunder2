using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
