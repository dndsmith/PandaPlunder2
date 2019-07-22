using UnityEngine;
using System.Collections;

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
