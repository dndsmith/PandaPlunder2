using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class createSceneHandler : MonoBehaviour {

    public gameData DB;
    public Button createButton;
    public InputField usr;
    public InputField pas;

    public string exclude = "<>:\"/\\|?*";

	// Use this for initialization
	void Start () {
        DB = FindObjectOfType<gameData>();
        createButton.onClick.AddListener(savePlayer);
        usr.onValidateInput += delegate (string input, int charIndex, char addedChar) { return Validate(addedChar); };
        pas.onValidateInput += delegate (string input, int charIndex, char addedChar) { return Validate(addedChar); };

    }
	
    private char Validate(char charToValidate)
    {
        if (exclude.Contains(charToValidate.ToString()))
        {

            charToValidate = '\0';

        }


        return charToValidate; 
    }

    void savePlayer()
    {
        Debug.Log("clicked!");
        PlayerInfo POut = new PlayerInfo(usr.text, pas.text);
        string jsonOut = JsonUtility.ToJson(POut);
        File.WriteAllText(/*path to player files*/Application.streamingAssetsPath + "/" + POut.name + ".json", jsonOut);


    }
}
