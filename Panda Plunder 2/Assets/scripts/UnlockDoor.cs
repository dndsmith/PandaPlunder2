using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public ExitDoor ED;

    // enter collider, door "opens" (disappears)
    private void OnTriggerEnter(Collider other)
    {
        ED.doorOpen();
    }
}
