using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScore : MonoBehaviour {


    public int score = 0;
    public int showScore = 0;
    public static int scoreTimer;
    ///public moveScore MS;

	// Use this for initialization
	void Start () {
		
	}
	
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
