using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteract : interaction {

    public int Calories;
    public AudioSource sfx;
    public gameScore GS;
    public sackFill SF;
    public Text nameOfFood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void act()
    {
        nameOfFood.text = transform.name;
        foreach(Transform t in transform)
        {

            GameObject.Destroy(t.gameObject);

        }
        GetComponent<BoxCollider>().enabled = false;
        GameObject.Destroy(transform.gameObject, sfx.clip.length);
        sfx.Play();
        SF.fill(Calories);
        GS.addScore(Calories);
    }
}
