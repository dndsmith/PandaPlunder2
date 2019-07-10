using UnityEngine;
using System.Collections;

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
