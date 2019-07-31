using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// OLD Game 1 but used in Game 2

public class GameScore : MonoBehaviour
{
    public int score = 0;
    public int showScore = 0;
    public static int scoreTimer;
	
	// Update is called once per frame
	void Update () {

        if(showScore < score)
        {
            showScore+=10;
            GetComponent<Text>().text = showScore.ToString();
        }
    }

    public void addScore(int more)
    {
        score += more;
        //MS.toView = true;
        scoreTimer = (more/10)+100;
    }
}
