using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
