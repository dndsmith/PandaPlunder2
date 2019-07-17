using UnityEngine;
using UnityEngine.SceneManagement;

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
