using UnityEngine;
using System.Collections;

public class MessageOnActivityStart : MonoBehaviour
{
    public string message;

    private void Start()
    {
        GetComponentInParent<ActivityController>().ActivityStarted += D_OnActivityStarted;
    }

    public void D_OnActivityStarted(object sender, System.EventArgs e)
    {
        MessagePanelController.DisplayMessage(message, 10f);
    }
}
