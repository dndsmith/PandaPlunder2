using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurkeyInterac : interaction{


    public Text GOtext;
    public Text subtext;
    public moveScore MS;
    public gameScore GS;
    public AudioSource RPAS;
    public AudioClip rpWin;
    public moveCharacter MC;
    public int Calories;
    public AudioSource sfx;
    public Animator A;

    public override void act()
    {
        GOtext.text = "Winner Winner!";
        subtext.text = "final score: " + (GS.score+Calories).ToString();
        MS.toView = true;
        MC.enabled = false;
        A.SetBool("victory", true);
        RPAS.clip = rpWin;
        RPAS.Play();

        foreach (Transform t in transform)
        {

            GameObject.Destroy(t.gameObject);

        }
        GetComponent<BoxCollider>().enabled = false;
        GameObject.Destroy(transform.gameObject, sfx.clip.length);
        sfx.Play();
    }

}
