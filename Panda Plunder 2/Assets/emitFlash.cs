using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitFlash : MonoBehaviour {

    public Material test;
    [Range(0, 10)]
    public float freq;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float a = (Mathf.Sin(Time.time*freq) + 1) /2;

        test.SetVector("_EmissionColor", new Vector4(0xCF, 0xCF, 0xCF, 0) * (a/200));

	}
}
