using UnityEngine;
using System.Collections.Generic;

// Game 2

/*
 *  Represent an activity involving a sequence of commands (e.g. dances).
 *  Contains extra data and logic to handle a sequence of player input once the activity is started
 *      and to evaluate that sequence against a correct sequence of commands.
 */

public class CommandActivity : ActivityController
{
    public string[] sequenceOfCommands;
    private List<string> playerInputSequence = new List<string>();
    private int indexOfFirstCorrectInput = 0;
    private string playerInputString = "";
    private bool correctAnswer = true;
    private bool activityStarted = false;

    private void Update()
    {
        if (activityStarted)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerInputSequence.Add("dance1");
                correctAnswer = CheckInput();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerInputSequence.Add("dance2");
                correctAnswer = CheckInput();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerInputSequence.Add("dance3");
                correctAnswer = CheckInput();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                playerInputSequence.Add("dance4");
                correctAnswer = CheckInput();
            }
        }
    }

    private bool CheckInput()
    {
        // TEMPORARY AND POOR DESIGN
        if (playerInputSequence.Count > sequenceOfCommands.Length) return true;

        for(int i = indexOfFirstCorrectInput; i < playerInputSequence.Count; i++)
        {
            if (playerInputSequence[i] != sequenceOfCommands[i - indexOfFirstCorrectInput])
            {
                //indexOfFirstCorrectInput = i + 1;
                MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(incorrectAnswer), 5f);
                return false;
            }
        }
        return true;
    }

    public override void StartActivity()
    {
        base.StartActivity();
        activityStarted = true;
    }

    public override void StopActivity()
    {
        base.StopActivity();
        activityStarted = false;
        if(correctAnswer && playerInputSequence.Count == sequenceOfCommands.Length)
        {
            gameScore.addScore(correctBonus);
            MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(goodJob), 5f);
        }
        else if(correctAnswer) // they correctly performed a subset of the sequence
        {
            MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(incorrectAnswer), 5f);
        }
    }
}
