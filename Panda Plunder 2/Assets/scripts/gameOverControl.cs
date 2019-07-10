using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverControl : MonoBehaviour {


    public moveScore MS;

    public moveCharacter MC;
    public Animator RPA;
    public AudioSource RPAS;
    public AudioClip RPlose;
    public Animator PA;
    public AudioSource PAS;
    public AudioClip Pwin;
    public Enemy PPF;

    private void OnTriggerEnter(Collider other)
    {

        PA.SetBool("victory", true);
        RPA.SetTrigger("failure");

        RPAS.clip = RPlose;
        PAS.clip = Pwin;
        RPAS.Play();
        PAS.Play();

        PPF.enabled = false;
        MS.toView = true;
        MC.enabled = false;

    }
}
