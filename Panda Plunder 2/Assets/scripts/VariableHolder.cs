using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Game 2

/*
 *  Can be thought of as a reference/pointer to a Variable.
 */

public class VariableHolder : MonoBehaviour
{
    private Variable theVariable;

    public void SetVariable(Variable v)
    {
        theVariable = v;
        GetComponent<Image>().sprite = v.varIcon;
    }

    public Variable GetVariable()
    {
        return theVariable;
    }

    public string GetItemType()
    {
        return theVariable.GetItemType();
    }

    public bool ContainsItem(InventoryItem item)
    {
        return theVariable.ContainsItem(item);
    }
}
