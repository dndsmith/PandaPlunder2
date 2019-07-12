using UnityEngine;
using System.Collections;

public class ActivityController : MonoBehaviour
{
    Variable[] variables;
    VariablesMenu variablesMenu;

    void Start()
    {
        variables = GetComponentsInChildren<Variable>();
        variablesMenu = FindObjectOfType<VariablesMenu>();
    }


    void Update()
    {

    }

    public void ShowVariables()
    {
        foreach (Variable v in variables)
            variablesMenu.AddVariable(v);
    }

    public void HideVariables()
    {
        variablesMenu.ClearVariables();
    }
}
