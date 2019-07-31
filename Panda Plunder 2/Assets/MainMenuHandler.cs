using UnityEngine;
using UnityEngine.SceneManagement;

// Game 2

public class MainMenuHandler : MonoBehaviour
{
    // FIXME: parse string for commands. It is the event data
    // COMMAND SYNTAX: <command_to_run>=<relevant_data>
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
