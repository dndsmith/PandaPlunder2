using UnityEngine;
using System.Collections.Generic;

public class MessageOnChestOpen : MonoBehaviour
{
    public List<ChestInteractable> chestsToSendMessageOn;
    public string messageToSend;

    private bool messageSent = false;

    private void Start()
    {
        foreach (ChestInteractable chest in chestsToSendMessageOn)
            chest.ChestOpened += C_OnChestOpened;
    }

    public void C_OnChestOpened(object sender, ChestOpenedEventArgs e)
    {
        if(chestsToSendMessageOn.Contains(e.chest) && !messageSent)
        {
            MessagePanelController.DisplayMessage(messageToSend, 5f);
            messageSent = true;
        }
    }
}
