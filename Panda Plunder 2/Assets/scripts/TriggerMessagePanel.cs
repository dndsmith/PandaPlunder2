using UnityEngine;
using UnityEngine.UI;

public class TriggerMessagePanel : MonoBehaviour
{
    public string messagesToSend;
    public Sprite spritesToAccompanyMessage;
    public float numSecondsToShowMessages;
    public bool destroyTriggerWhenDone;
    public bool hideMessagePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (hideMessagePanel) MessagePanelController.HideMessage();
        else if (spritesToAccompanyMessage != null) MessagePanelController.DisplayMessage(messagesToSend, spritesToAccompanyMessage, numSecondsToShowMessages);
        else MessagePanelController.DisplayMessage(messagesToSend, numSecondsToShowMessages);
        if (destroyTriggerWhenDone) Destroy(this.gameObject);
    }
}
