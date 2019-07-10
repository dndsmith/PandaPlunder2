using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public GameObject Walls;
    public GameObject Floor;
    public Material onMat;
    public Material offMat;
    public Material[] mats = new Material[2];
    public int swt = 0;

	// Use this for initialization
	void Start () {

        mats[1] = onMat;
        mats[0] = offMat;
        switchLight();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
        {

            swt = swt ^ 1;
            switchLight();


        }

	}

    public void switchLight()
    {

        foreach(Transform t in Walls.transform)
        {

            t.gameObject.GetComponent<Renderer>().material = mats[swt];

        }
        Floor.GetComponent<Renderer>().material = mats[swt];

    }

}
