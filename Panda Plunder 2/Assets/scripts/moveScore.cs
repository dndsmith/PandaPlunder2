using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// was too lazy to completely redo this, so I just added a third point lol
// definitely a mess, sorry

public class moveScore : MonoBehaviour {


    public bool toView = false;
    public GameObject pointA;
    public GameObject pointB;
	
	// Update is called once per frame
	void Update () {
        if (toView)
        {
            GetComponent<RectTransform>().localPosition = Vector3.Lerp(GetComponent<RectTransform>().localPosition, pointA.GetComponent<RectTransform>().localPosition, 0.3f);
        }
        else
        {
            GetComponent<RectTransform>().localPosition = Vector3.Lerp(GetComponent<RectTransform>().localPosition, pointB.GetComponent<RectTransform>().localPosition, 0.1f);
        }
	}
}
