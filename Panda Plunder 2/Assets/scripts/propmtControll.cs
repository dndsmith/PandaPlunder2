using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class propmtControll : MonoBehaviour {



    public Image prompt;
    public Camera cam;
    public bool interactFound;
    public GameObject interactableObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if((Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Space)) && interactFound)
        {
            Component[] A = interactableObj.GetComponents(typeof(interaction));
            foreach(interaction B in A)
            {
                B.act();
            }
            prompt.enabled = false;
            interactFound = false;
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        prompt.enabled = true;
        interactFound = true;
        interactableObj = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        prompt.rectTransform.position = cam.WorldToScreenPoint(other.gameObject.transform.position + new Vector3(1, 1, 0));

    }
    private void OnTriggerExit(Collider other)
    {
        prompt.enabled = false;
        interactFound = false;
    }
}
