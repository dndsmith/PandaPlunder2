using UnityEngine;
using UnityEngine.UI;
using System;

public class RandomMessageGenerator : MonoBehaviour
{
    Text message;
    string[] randomMessages =
    {
        "Now with more blatant sarcasm!",
        "Different look , also different taste!",
        "2 is better than 1",
        "Choose the adventure!",
        "Wow your friends with your computational skills!",
        "Bill Gates approves! [citation needed]",
        "New and Imporved!",
    };
    System.Random rand = new System.Random();

    void Start()
    {
        message = GetComponent<Text>();
        message.text = randomMessages[rand.Next(randomMessages.Length)];
    }
}
