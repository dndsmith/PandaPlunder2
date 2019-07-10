using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionControl : MonoBehaviour {

    public GameObject BossQuestion;
    public ExitDoor ED;
    public List<GameObject> questions;

    public List<System.DateTime> times;
    public int[] answers;
    public int[] indexes;
    public int questionsAnswered;
    public int rightQuestions;

    public int timer;

    private void Start()
    {
        questionsAnswered = 0;
        rightQuestions = 0;
        answers = new int[questions.Count];
        indexes = new int[questions.Count];
        times = new List<System.DateTime>();
    }

    void Update () {

        
        if(questions.Count == 1)
        {
            ED.setGlow(1f);
            BossQuestion.SetActive(true);

        }
        else if(questions.Count == 0 && ED != null)
        {

            ED.doorOpen();

        }

        timer++;

    }
}
