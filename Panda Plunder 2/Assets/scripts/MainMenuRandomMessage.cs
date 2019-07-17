using UnityEngine;
using UnityEngine.UI;

public class MainMenuRandomMessage : MonoBehaviour
{
    Text message;
    string[] randomMessages =
    {
        "Fun Time Jamboree!",
        "Different look , also different taste!",
        "2 is better than 1!",
        "Given the choice, choose the adventure!",
        "Wow your friends with your computational skills!",
        "Now with more science!",
        "New and Imporved!",
    };

    void Start()
    {
        message = GetComponent<Text>();
        message.text = RandomMessageGenerator.GenerateRandomMessage(randomMessages);
    }
}
