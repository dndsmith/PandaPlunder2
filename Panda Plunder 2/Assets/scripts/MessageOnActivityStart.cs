using UnityEngine;
using System.Collections;

// Game 2

/*
 *  Displays a message at the start of an activity.
 */

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
