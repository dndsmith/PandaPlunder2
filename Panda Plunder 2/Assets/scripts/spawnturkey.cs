using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnturkey : MonoBehaviour {


    public Text GOtext;
    public Text subtext;
    public moveScore MS;
    public gameScore GS;
    public AudioSource RPAS;
    public moveCharacter MC;
    public Animator A;
    public GameObject turkey;


    // Use this for initialization
    void Start () {

        int pick = Random.Range(0, transform.childCount);
        GameObject g = GameObject.Instantiate(turkey);
        g.GetComponent<TurkeyInterac>().GOtext = this.GOtext;
        g.GetComponent<TurkeyInterac>().subtext = this.subtext;
        g.GetComponent<TurkeyInterac>().MS = this.MS;
        g.GetComponent<TurkeyInterac>().GS = this.GS;
        g.GetComponent<TurkeyInterac>().RPAS = this.RPAS;
        g.GetComponent<TurkeyInterac>().MC = this.MC;
        g.GetComponent<TurkeyInterac>().A = this.A;
        g.transform.position = new Vector3(transform.GetChild(pick).position.x - 0.3f, 5.83f, transform.GetChild(pick).position.z); 

    }
	
	// Update is called once per frame

}
