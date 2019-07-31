using UnityEngine;
using System.Collections;

// Game 2
// NOT USED

public class AssignMenu : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
