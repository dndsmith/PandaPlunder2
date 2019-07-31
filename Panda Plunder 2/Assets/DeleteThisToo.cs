using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game 2

public class DeleteThisToo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("scenes/Tutorial/MainScreen", LoadSceneMode.Single);
    }
}
