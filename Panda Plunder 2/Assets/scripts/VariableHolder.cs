using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
}
