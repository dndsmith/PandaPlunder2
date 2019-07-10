using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class gameData : MonoBehaviour {

    private static bool created = false;
    public PlayerInfo PI;

    public int openMod;

    void Awake()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
        openMod = 0;
    }

    public void LoadScene(string dest)
    {
        
        string destFull = "scenes/" + dest;
        if (SceneManager.GetActiveScene().name != dest)
        {
            SceneManager.LoadScene(destFull, LoadSceneMode.Single);
        }
    }

    public bool loadPlayer(string username, string password)
    {
        string filePath = Application.streamingAssetsPath + "/" + username + ".json";
        if (File.Exists(filePath))
        {
            string jsonIn = File.ReadAllText(filePath);
            PI = JsonUtility.FromJson<PlayerInfo>(jsonIn);

            if (PI.password.Equals(password))
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        return false;

    }

    public void SavePlayer()
    {

        string jsonOut = JsonUtility.ToJson(PI);
        File.WriteAllText(/*path to player files*/Application.streamingAssetsPath+"/" + PI.name + ".json", jsonOut);

    }
}
