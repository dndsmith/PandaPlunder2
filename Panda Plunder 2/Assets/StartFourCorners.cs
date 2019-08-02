using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

public class StartFourCorners : MonoBehaviour
{
    FourCornersInteractable FCC;
    BoxCollider[] colliders;
    public bool useTriggerFromCollider = false;

    private void Start()
    {
        FCC = GetComponentInChildren<FourCornersInteractable>();
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
