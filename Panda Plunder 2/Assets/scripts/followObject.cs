using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour {

    public GameObject leader;
    public float xOffset;
    public float zOffset;


	// Use this for initialization
	void Start () {

        xOffset = leader.transform.position.x - transform.position.x;
        zOffset = leader.transform.position.z - transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(leader.transform.position.x - xOffset, transform.position.y, leader.transform.position.z - zOffset);
		
	}
}
