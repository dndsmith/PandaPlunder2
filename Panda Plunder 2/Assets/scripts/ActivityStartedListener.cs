using UnityEngine;
using System.Collections;

public class ActivityStartedListener : MonoBehaviour
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
