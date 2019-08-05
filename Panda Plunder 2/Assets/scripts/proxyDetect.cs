using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1

/*
 *  I assume this was used on the Panda enemies to trigger them chasing the player when
 *  the player walked in proximity to the Panda.
 */

public class proxyDetect : MonoBehaviour {


    public Enemy E;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        E.nearPlayer = true;
        E.chasee = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {

        E.nearPlayer = false;

    }
}
