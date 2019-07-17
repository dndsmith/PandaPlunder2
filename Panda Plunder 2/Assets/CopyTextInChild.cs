using UnityEngine;
using UnityEngine.UI;

public class CopyTextInChild : MonoBehaviour
{
    Text[] myText;
    
    void Start()
    {
        myText = GetComponentsInChildren<Text>();
        myText[0].text = myText[1].text;
    }
}
