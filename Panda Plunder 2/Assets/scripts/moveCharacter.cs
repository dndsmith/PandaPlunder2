using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{

    public float speed = 0;
    public float maxSpeed = 1;
    public float HPower;
    public float VPower;
    public Vector2 prevInput;
    public Vector2 stickInput;

    public Animator A;

    public bool walled = false;

    public CapsuleCollider SoundCollider;

    void FixedUpdate()
    {


        HPower = Input.GetAxis("Horizontal");
        VPower = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {

            VPower = 1;

        }
        if (Input.GetKey(KeyCode.A))
        {

            HPower = -1;

        }
        if (Input.GetKey(KeyCode.S))
        {

            VPower = -1;

        }
        if (Input.GetKey(KeyCode.D))
        {

            HPower = 1;

        }

        float deadzone = 0.25f;
        float go = 0;
        stickInput = new Vector2(HPower, VPower);
        if (stickInput.magnitude < deadzone)
        {
            A.SetBool("Running", false);
            stickInput = Vector2.zero;
        }

        else
        {
            A.SetBool("Running", true);
            //get new direction here
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
            Vector3 Direction = new Vector3(stickInput.x, 0, stickInput.y);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), 0.1f);
            go = maxSpeed;

        }


        speed = Mathf.Lerp(speed, go, 0.1f);
        transform.Translate(Vector3.forward * speed);
    }

}
