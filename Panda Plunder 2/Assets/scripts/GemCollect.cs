using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

public class GemCollect : MonoBehaviour
{
    public GameScore GS;
    public int timeToCollectNextGem = 75;
    public int pickupScore = 250;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
        GS.addScore(pickupScore);
    }
}
