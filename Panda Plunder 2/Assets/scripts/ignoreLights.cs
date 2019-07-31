using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OLD Game 1 but used in Game 2

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
