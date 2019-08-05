using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game 2

/*
 *  Goes back to the Main Screen when player enters trigger.
 *  Not sure where this is used anymore, but it can be deleted.
 */

public class DeleteThisToo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("scenes/Tutorial/MainScreen", LoadSceneMode.Single);
    }
}
