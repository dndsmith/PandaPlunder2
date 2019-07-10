using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFourCorners : MonoBehaviour
{
    FourCornersController FCC;
    BoxCollider[] colliders;
    public bool useTriggerFromCollider = false;

    private void Start()
    {
        FCC = GetComponentInChildren<FourCornersController>();
        colliders = GetComponentsInChildren<BoxCollider>();
        int size = colliders.Length;
        int i = (useTriggerFromCollider) ? 1 : 0;
        for(; i < size; i++)
        {
            colliders[i].enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(useTriggerFromCollider)
            BeginFourCorners();
    }

    public void BeginFourCorners()
    {
        FCC.EnableLights();
        foreach (BoxCollider bc in colliders)
        {
            bc.enabled = true;
        }
    }
}
