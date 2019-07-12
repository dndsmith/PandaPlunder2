using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // FIXME: parse string for commands. It is the event data
    // COMMAND SYNTAX: commandToRun_relevantData
    public virtual void OnButtonClick(string command)
    {
        string[] split = command.Split(new char[] { '=' });
        if(split == null || split.Length < 2 || split.Length > 2)
        {
            Debug.Log("Invalid Menu command: " + command);
        }
        else
        {
            // cmd: load
            // function: LoadScene
            if(split[0] == "load")
            {
                LoadScene(split[1]);
            }
        }
    }

    private void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
