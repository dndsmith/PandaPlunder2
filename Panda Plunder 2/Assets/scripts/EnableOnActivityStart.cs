using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Sets a GameObject to active at the start of an activity and inactive before the activity starts.
 */

public class EnableOnActivityStart : MonoBehaviour
{
    public GameObject objectToEnable;

    private void Start()
    {
        GetComponentInParent<ActivityController>().ActivityStarted += D_OnActivityStarted;
        objectToEnable.SetActive(false);
    }

    public void D_OnActivityStarted(object sender, System.EventArgs e)
    {
        objectToEnable.SetActive(true);
    }
}
