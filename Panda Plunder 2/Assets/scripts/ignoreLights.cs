using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1 but used in Game 2

/*
 *  Not 100% sure of its function, but I think it has to do with which lights
 *  are turned on and off in the scene. That's probably not exactly right, but it
 *  is related to the outline effect used in Game 1.
 */

public class ignoreLights : MonoBehaviour {


    public List<Light> Lights;

    void OnPreCull()
    {
        foreach (Light light in Lights)
        {
            light.enabled = false;
        }
    }

    void OnPostRender()
    {
        foreach (Light light in Lights)
        {
            light.enabled = true;
        }
    }
    

}
