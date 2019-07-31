using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Game 2

public class FlashCardActivity : ActivityController
{
    public string correctColorAnswer;
    public moveScore questionMover;
    public Sprite questionSlide;

    private FourCornersController FCC;
    private int scoreToAdd = 0;

    void Start()
    {
        FCC = GetComponentInChildren<FourCornersController>();
        questionMover.toView = false;
    }

    public override void StartActivity()
    {
        questionMover.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = questionSlide;
        questionMover.toView = true;
        base.StartActivity();
        StartCoroutine(FourCornersInput());
    }

    public override void StopActivity()
    {
        base.StopActivity();
        questionMover.toView = false;
        gameScore.addScore(scoreToAdd);
    }

    IEnumerator FourCornersInput()
    {
        string choice = "";
        while (choice == "")
        {
            if (FCC.IsOnHigh("red"))
                choice = "red";
            else if (FCC.IsOnHigh("yellow"))
                choice = "yellow";
            else if (FCC.IsOnHigh("green"))
                choice = "green";
            else if (FCC.IsOnHigh("blue"))
                choice = "blue";
            yield return 0;
        }

        if (choice == correctColorAnswer)
        {
            scoreToAdd = correctBonus;
            MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(goodJob), 5f);
        }
        else MessagePanelController.DisplayMessage(RandomMessageGenerator.GenerateRandomMessage(incorrectAnswer), 5f);
    }
}
