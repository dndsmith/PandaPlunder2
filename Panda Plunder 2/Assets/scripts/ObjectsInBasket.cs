using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2
// NOT USED

/*
 *  Used to add points to the player's score when a gem was dropped onto the "basket"
 *  and destroy the gem on contact.
 */

public class ObjectsInBasket : MonoBehaviour
{
    public GameScore GS;
    private const int placedInBasketScore = 500;

    // reacts only to gems placed in basket
    private void OnTriggerEnter(Collider other)
    {
        // collider part of if-stmt is to account for the pickup range collider
        if(other.gameObject.CompareTag("Gem") && !other.isTrigger)
        {
            GS.addScore(placedInBasketScore);
            Destroy(other.gameObject);
        }
    }
}
