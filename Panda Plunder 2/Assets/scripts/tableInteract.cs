using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableInteract : interaction {


    public AudioSource AS;
    public GameObject soundRange;

    public override void act()
    {

        //play audio source
        //activate sound range

        AS.Play();
        GameObject.Instantiate(soundRange);



    }
}
