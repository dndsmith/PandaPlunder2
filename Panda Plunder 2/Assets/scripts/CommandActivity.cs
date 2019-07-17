using UnityEngine;
using System.Collections.Generic;

// AKA Dance Activity

public class CommandActivity : ActivityController
{
    public string[] sequenceOfCommands;
    private List<string> playerInputSequence = new List<string>();
    private int indexOfFirstCorrectInput = 0;
    private string playerInputString = "";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInputSequence.Add("dance1");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerInputSequence.Add("dance2");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerInputSequence.Add("dance3");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerInputSequence.Add("dance4");
        }
    }

    private void CheckInput(string command)
    {
        for(int i = indexOfFirstCorrectInput; i < playerInputSequence.Count; i++)
        {
            if (playerInputSequence[i] != sequenceOfCommands[i - indexOfFirstCorrectInput])
            {
                //indexOfFirstCorrectInput = i + 1;
                MessagePanelController.DisplayMessage("Ouch! That wasn't quite right. Better luck next time!", 4f);
            }
        }
    }
}
