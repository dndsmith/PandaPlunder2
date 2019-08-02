using UnityEngine;
using UnityEngine.SceneManagement;

// Game 2

/*
 *  Activates a sphere which acts like a "finish line" for the player to walk through to get back to
 *  the main menu after all activities in a level are complete. Hences, it ends the level.
 */

// Better design would be to change ActivityCompleted to an event listener for the event ActivityController.ActivityStopped
// Also, change it so that the LoadScene back to MainScreen is in a separate function (for the potential pause menu)

public class EndLevel : MonoBehaviour
{
    private int numActivities;
    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;

    private void Awake()
    {
        numActivities = FindObjectsOfType<ActivityController>().Length;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       SceneManager.LoadScene("scenes/Tutorial/MainScreen", LoadSceneMode.Single);
    }

    public void ActivityCompleted()
    {
        numActivities--;
        if (numActivities <= 0)
        {
            meshRenderer.enabled = true;
            sphereCollider.enabled = true;
            MessagePanelController.DisplayMessage("You've answered all the questions! Go back to where you started to exit", 10f);
        }
    }
}
