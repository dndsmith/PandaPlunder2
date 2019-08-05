using UnityEngine;
using System.Collections.Generic;

// Game 2

/*
 *  Controls the menu which displays the list of available variables in an activity.
 */

public class VariablesMenu : MonoBehaviour
{
    public GameObject dropZonePrefab;
    public GameObject variablePrefab;
    List<Variable> variables = new List<Variable>();

    public void AddVariable(Variable v)
    {
        variables.Add(v);
        GameObject dropZone = Instantiate(dropZonePrefab, transform.position, Quaternion.identity, transform);
        GameObject variable = Instantiate(variablePrefab, dropZone.transform.position, Quaternion.identity, dropZone.transform);
        variable.GetComponent<DragItem>().DropInZone(dropZone.GetComponent<DropZone>());
        variable.GetComponent<VariableHolder>().SetVariable(v);
    }

    public void RemoveVariable(Variable v)
    {
        foreach(DropZone DZ in GetComponentsInChildren<DropZone>())
        {
            if(variables.Contains(DZ.GetComponentInChildren<VariableHolder>().GetVariable()))
            {
                Destroy(DZ.gameObject);
            }
        }
        variables.Remove(v);
    }

    public void ClearVariables()
    {
        variables.Clear();
        foreach (DropZone DZ in GetComponentsInChildren<DropZone>())
            Destroy(DZ.gameObject);
    }
}
