using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiibleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MessagePanelController.DisplayMessage("WOWw, that's magic!!!", 5f);
    }
}
