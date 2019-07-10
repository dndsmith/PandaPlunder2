using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
