using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour {


    public GameObject[] cams;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {

            for(int i = 0; i < 4; i++)
            {
                cams[i].SetActive(true);

            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            cams[0].SetActive(false);
            cams[1].SetActive(true);
            cams[2].SetActive(false);
            cams[3].SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {


            cams[0].SetActive(false);
            cams[1].SetActive(false);
            cams[2].SetActive(true);
            cams[3].SetActive(false);

        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            cams[0].SetActive(false);
            cams[1].SetActive(false);
            cams[2].SetActive(false);
            cams[3].SetActive(true);

        }




    }
}
