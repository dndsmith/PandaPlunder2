using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// OLD Game 1

/*
 *  Records data in database (gameData) about the player's performance on this level
 *  when the player enters a trigger with this script attached. It then calls on EndGame
 *  to load the next level (which in Game 1 is always the Level Select screen).
 */

public class LevelOut : MonoBehaviour {

    public EndGame ender;
    public gameData DB;
    public GameScore GS;
    public questionControl QC;

    public int returnmod;

    public string nextLevel;

    public int threeStarScore;
    public int levelNum;

    public bool endLevel;

    private void Start()
    {
        DB = FindObjectOfType<gameData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!DB.PI.levelData[levelNum].played)
        {
            DB.PI.levelData[levelNum].played = true;
            DB.PI.levelLock++;
            
        }
        else
        {

            nextLevel = "Menus/levelSelect";

        }

        if (endLevel)
        {

            nextLevel = "Menus/levelSelect"; // should L be capitalized here?

        }
        
        else if(GS.score > DB.PI.levelData[levelNum].score)
        {
            DB.PI.levelData[levelNum].score = GS.score;
            if (QC.rightQuestions == 5)
            {
                if(GS.score > 7000)
                    DB.PI.levelData[levelNum].stars = 3;
                else
                    DB.PI.levelData[levelNum].stars = 2;

            }
            else
            {

                DB.PI.levelData[levelNum].stars = Mathf.RoundToInt((3.0f * (float)(QC.rightQuestions)) / 5.0f);

            }

        }
        for (int i = 0; i < QC.questionsAnswered; i++)
        {
            QuestionData QD = DB.PI.questionData[QC.indexes[i]];
            QD.times.Add(System.DateTime.Now.ToString());
            switch (QC.answers[i])
            {
                case 1:
                    QD.answers += "A";
                    break;
                case 2:
                    QD.answers += "B";
                    break;
                case 3:
                    QD.answers += "C";
                    break;
                case 4:
                    QD.answers += "D";
                    break;
            }

        }
        DB.openMod = returnmod;
        ender.endLevel(nextLevel);

    }


}
