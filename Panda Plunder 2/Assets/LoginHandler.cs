using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour {

    public gameData DB;
    public Button createButton;
    public InputField usr;
    public InputField pas;
    public Text err;

    public string exclude = "<>:\"/\\|?*";

    // Use this for initialization
    void Start()
    {
        DB = FindObjectOfType<gameData>();
        createButton.onClick.AddListener(loadPlayer);
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

    void loadPlayer()
    {
        if(DB.loadPlayer(usr.text, pas.text))
        {

            Debug.Log("success");
            if (DB.PI.levelLock == 0)
                DB.LoadScene("Menus/Intro");
            else
                DB.LoadScene("Menus/levelSelect");

        }
        else
        {
            
            Debug.Log("failure");
            err.text = "Incorrect Username or Password!";

        }

    }
}
