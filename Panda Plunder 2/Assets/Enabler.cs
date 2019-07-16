using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    public bool enableAtStart;
    private AssignmentMenu assignmentMenu;

    private void Awake()
    {
        assignmentMenu = FindObjectOfType<AssignmentMenu>();
        assignmentMenu.MenuOpened += C_OnMenuOpened;
    }

    private void Start()
    {
        gameObject.SetActive(enableAtStart);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    protected void C_OnMenuOpened(object sender, System.EventArgs e)
    {
        Enable();
    }
}
