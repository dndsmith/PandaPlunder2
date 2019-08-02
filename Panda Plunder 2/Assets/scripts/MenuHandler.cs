using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// OLD Game 1

/*
 *  Handled button presses and navigation within the Game 1 LevelSelect menu.
 */

public class MenuHandler : MonoBehaviour {

    public gameData DB;

    public List<Canvas> modules;
    public List<LevelButtonHandler> buttons;
    public List<string> levels;

    public Canvas currentCan;


	void Start () {
        DB = FindObjectOfType<gameData>();
        currentCan = modules[0];
        ModuleButtonPressed(DB.openMod);

        for(int i = 0; i < DB.PI.levelLock; i++)
        {

            buttons[i].turnOn();
            buttons[i].setStars(DB.PI.levelData[i].stars);
            buttons[i].setScore(DB.PI.levelData[i].score);

        }

	}

    public void ModuleButtonPressed(int mod)
    {

        currentCan.enabled = false;
        modules[mod].enabled = true;
        currentCan = modules[mod];


    }

    public void LevelButtonPressed(int lv)
    {

        DB.LoadScene(levels[lv]);

    }
}
