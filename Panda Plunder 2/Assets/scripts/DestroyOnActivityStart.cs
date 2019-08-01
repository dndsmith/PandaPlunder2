using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Destroys a GameObject at the start of an activity.
 */

public class DestroyOnActivityStart : MonoBehaviour
{
    private void Start()
    {
        GetComponentInParent<ActivityController>().ActivityStarted += D_OnActivityStarted;
    }

    public void D_OnActivityStarted(object sender, System.EventArgs e)
    {
        Destroy(this.gameObject);
    }
}
