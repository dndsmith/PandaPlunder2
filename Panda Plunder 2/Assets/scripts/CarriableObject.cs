using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

public class CarriableObject : MonoBehaviour
{
    public bool InPickupRange { get; set; }
    private Rigidbody RB;
    private bool isBeingCarried = false;
    private float objectHeight = 0.6f;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InPickupRange && Input.GetKeyDown(KeyCode.L))
        {
            if(isBeingCarried) // put down
            {
                PutDown(GameObject.FindGameObjectWithTag("Player"));
            }
            else // pick up
            {
                PickUp(GameObject.FindGameObjectWithTag("Player"));
            }
        }
    }

    // Player is within range to pick up object
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Sparkle"))
        {
            InPickupRange = true;
            Debug.Log("in pickup range");
        }
    }

    // Player is out of range to pick up object
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Sparkle"))
        {
            InPickupRange = false;
            Debug.Log("out of pickup range");
        }
    }

    public void PickUp(GameObject carrier)
    {
        if(isBeingCarried) return;
        transform.parent = carrier.transform;
        RB.isKinematic = true; // so object stays in air
        if(carrier.CompareTag("Player")) transform.Translate(Vector3.up * objectHeight); // would be good to do some error catching on this...
        isBeingCarried = true;
        Debug.Log("pick up");
    }

    public void PutDown(GameObject carrier)
    {
        if(!isBeingCarried) return;
        transform.parent = null;
        RB.isKinematic = false; // so object falls down
        isBeingCarried = false;
        Debug.Log("put down");
    }

    public bool BeingCarried()
    {
        return isBeingCarried;
    }
}
