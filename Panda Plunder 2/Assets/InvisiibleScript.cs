using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DELETE THIS, was demo for coding camp

public class InvisiibleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MessagePanelController.DisplayMessage("WOWw, that's magic!!!", 5f);
    }
}
