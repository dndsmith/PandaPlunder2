using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class AssignmentActivity : ActivityController
{
    // specifies which variables we want to check for correct type and count assigned by the student
    public List<string> variableNames = new List<string>();
    public string[] typesForEachVariable;
    public int[] countsForEachVariable;

    // variables in children and the variables menu
    private Variable[] variables;
    private VariablesMenu variablesMenu;

    void Start()
    {
        variables = GetComponentsInChildren<Variable>();
        variablesMenu = FindObjectOfType<VariablesMenu>();
    }

    public override void StopActivity()
    {
        base.StopActivity();
        if(CheckVariables()) gameScore.addScore(correctBonus);
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

    private bool CheckVariables()
    {
        foreach(Variable variable in variables)
        {
            int index = variableNames.IndexOf(variable.varName);
            if(index == -1)
            {
                MessagePanelController.DisplayMessage("oops, didn't find the chest...tell the nearest adult", 5f);
            }
            else if((typesForEachVariable[index] != variable.GetItemType()) || countsForEachVariable[index] != variable.GetValue().Length)
            {
                MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(incorrectAnswer), 3f);
                return false;
            }
        }
        MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(goodJob), 3f);
        return true;
    }
}
