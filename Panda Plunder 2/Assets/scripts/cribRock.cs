using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1
// NOT USED

public class cribRock : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(0, 0, 2f*Mathf.Sin(Time.time));
		
	}
}
