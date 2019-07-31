using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 1 or 2, don't remember
// NOT USED

public class UnlockDoor : MonoBehaviour
{
    public ExitDoor ED;

    // enter collider, door "opens" (disappears)
    private void OnTriggerEnter(Collider other)
    {
        ED.doorOpen();
    }
}
