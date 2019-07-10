using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Pathfinding
{


    int counter = 5;
    public bool nearPlayer = false;

    public GameObject chasee;
    public float rangeXA;
    public float rangeXB;
    public float rangeYA;
    public float rangeYB;
    public Vector3 endPosition;
    public Animator PA;


    void Start ()
	{
        
    }

	void Update ()
	{
        //If i hit the P key i will get a path from my position to my end position
        //if (start == true)
        if (!nearPlayer)
        {
            if (counter > 0)
            {
                counter--;
                if (counter == 0)
                {
                    endPosition = new Vector3(Random.Range(rangeXA, rangeXB), 0, Random.Range(rangeYA, rangeYB));
                    FindPath(transform.position, endPosition);
                }
            }

            else
            {
                //If path count is bigger than zero then call a move method
                if (Path.Count > 0)
                {
                    PA.SetBool("running", true);
                    Move();
                    if (Path.Count == 0)
                    {
                        PA.SetBool("running", false);
                        counter = 50;

                    }

                }
                else
                {
                    counter = 1;

                }
            }


        }

        else
        {

            endPosition = chasee.transform.position;
            FindPath(transform.position, endPosition);
            if (Path.Count > 0)
                Move();



        }
        

    }
    
    
}