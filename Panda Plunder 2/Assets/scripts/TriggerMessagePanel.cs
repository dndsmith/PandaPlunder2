using UnityEngine;
using UnityEngine.UI;

// Game 2

public class TriggerMessagePanel : MonoBehaviour
{
    public string messageToSend;
    public Sprite spriteToAccompanyMessage;
    public float numSecondsToShowMessages;
    public bool destroyTriggerWhenDone;
    public bool hideMessagePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (hideMessagePanel) MessagePanelController.HideMessage();
        else if (spriteToAccompanyMessage != null) MessagePanelController.DisplayMessage(messageToSend, spriteToAccompanyMessage, numSecondsToShowMessages);
        else MessagePanelController.DisplayMessage(messageToSend, numSecondsToShowMessages);
        if (destroyTriggerWhenDone) Destroy(this.gameObject);
    }
}
