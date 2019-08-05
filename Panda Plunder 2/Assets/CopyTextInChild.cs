using UnityEngine;
using UnityEngine.UI;

// Game 2

/*
 *  Very specific purpose for the Main Screen.
 *  Used on the Random Message to make sure text and its outline match.
 */

public class CopyTextInChild : MonoBehaviour
{
    Text[] myText;
    
    void Start()
    {
        myText = GetComponentsInChildren<Text>();
        myText[0].text = myText[1].text;
    }
}
