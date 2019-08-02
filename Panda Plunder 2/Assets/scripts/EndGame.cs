using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// OLD Game 1

/*
 *  Loads next level/scene after a level is completed. If not resetting, writes the player's data
 *  to their save file.
 */

public class EndGame : MonoBehaviour {

    public wipeControl WP;
    public int timerSetting;
    private int timer;
    public bool ending = false;
    public string levelToProceed;
    public string thisLevel;

    public bool resetting;

    public gameData DB;


	// Use this for initialization
	void Start () {

        DB = FindObjectOfType<gameData>();
		
	}

    // Update is called once per frame
    public void Update()
    {
		
        if ((Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.P))&& !ending)
        {
            endLevel(thisLevel);
            resetting = true;

        }
		
        if (ending)
        {
            if (timer > 0)
            {
                timer--;

            }
            else
            {
                if(!resetting)
                    DB.SavePlayer();
                DB.LoadScene(levelToProceed);
            }
        }
    }

    public void endLevel(string level)
    {
        //takes a level name and loads it
        //TODO - if this is the last level in a list, go to menu
        //       else, go to next level

        ending = true;
        timer = timerSetting;
        WP.wipe();
        levelToProceed = level;


    }
}
