using UnityEngine;
using System.Collections;

public class DeleteThis : MonoBehaviour
{
    gameData DB;
    // Use this for initialization
    void Start()
    {
        DB = FindObjectOfType<gameData>();
        if(DB.PI.levelData.Count < 16)
        {
            DB.PI.levelData.Add(new LevelData(16));
            for(int i = 75; i < 80; i++)
                DB.PI.questionData.Add(new QuestionData(i));
        }
        if (DB.PI.levelLock < 15) DB.PI.levelLock = 15;
    }
}
