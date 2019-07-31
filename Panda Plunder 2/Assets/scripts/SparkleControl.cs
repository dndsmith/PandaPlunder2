using System;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

// A character controller

public class SparkleControl : Pathfinding
{
    // containers of objects
    public List<Interactable> interactables;

    // booleans
    private bool initial = true;

    private void Update()
    {
        /*if (destinations.Count > 0)
        {
            FindPath(transform.position, destinations.Peek().Item1);
            if (Path.Count > 0)
            {
                Move();
                initial = false;
            }
            else if (!initial && Path.Count == 0)
            {
                PerformAction(destinations.Peek().Item2);
                destinations.Dequeue();
                initial = true;
            }
        }*/
    }

    // add an Interactable as a listener
    public void AddInteractable(Interactable i)
    {
        interactables.Add(i);
    }
}
