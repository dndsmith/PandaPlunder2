using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionInteraction : interaction {


    public moveScore questionBox;
    public RawImage questionImage;
    public Texture2D questionImg;
    public moveCharacter MC;

    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource sfx;

    public questionControl QC;

    public Text questionNumber;
    public gameScore GS;

    public FourCornersController FCC;
    public StartFourCorners startFourCorners;

    public int correct;
    public int questionIndex;

    public bool trueFalse;

    public int outBonus = 0;
    const int TIMEBONUS = 1000;


    public override void act()
    {
        questionImage.texture = questionImg;
        questionBox.toView = true;
        GetComponent<BoxCollider>().enabled = false;
        MC.enabled = false;
        if (FCC == null)
            StartCoroutine(questionInput());
        else
        {
            MC.enabled = true;
            startFourCorners.BeginFourCorners();
            StartCoroutine(QuestionInputFourCorners());
        }
        outBonus += (QC.timer * 3) < TIMEBONUS ? TIMEBONUS - (QC.timer * 3) : 0;
        QC.timer = 0;

    }

    IEnumerator questionInput()
    {
        int choice = 0;
        while (choice == 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                choice = 1;
            else if (Input.GetKeyDown(KeyCode.X))
                choice = 2;
            else if (Input.GetKeyDown(KeyCode.C)&&!trueFalse)
                choice = 3;
            else if (Input.GetKeyDown(KeyCode.V)&&!trueFalse)
                choice = 4;
            yield return 0;
        }

        
        questionBox.toView = false;
        AudioClip outSound;
        outBonus += (QC.timer * 3) < TIMEBONUS ? TIMEBONUS - (QC.timer * 3) : 0;
        if (choice == correct)
        {
            GS.addScore(outBonus);
            QC.rightQuestions++;
            outSound = correctSound;
        }
        else
        {
            outSound = incorrectSound;
        }
        
        foreach(Transform t in transform)
        {

            Destroy(t.gameObject);

        }
        QC.questions.Remove(transform.gameObject);
        QC.indexes[QC.questionsAnswered] = questionIndex;
        QC.times.Add(System.DateTime.Now);
        QC.answers[QC.questionsAnswered] = choice;
        QC.questionsAnswered++;
        MC.enabled = true;
        sfx.clip = outSound;
        Destroy(transform.gameObject, sfx.clip.length);
        sfx.Play();
       

    }

    IEnumerator QuestionInputFourCorners()
    {
        int choice = 0;
        while (choice == 0)
        {
            if (FCC.IsOnHigh("red"))
                choice = 1;
            else if (FCC.IsOnHigh("yellow"))
                choice = 2;
            else if (FCC.IsOnHigh("green") && !trueFalse)
                choice = 3;
            else if (FCC.IsOnHigh("blue") && !trueFalse)
                choice = 4;
            yield return 0;
        }


        questionBox.toView = false;
        AudioClip outSound;
        outBonus += (QC.timer * 3) < TIMEBONUS ? TIMEBONUS - (QC.timer * 3) : 0;
        if (choice == correct)
        {
            GS.addScore(outBonus);
            QC.rightQuestions++;
            outSound = correctSound;
        }
        else
        {
            outSound = incorrectSound;
        }

        foreach (Transform t in transform)
        {

            Destroy(t.gameObject);

        }
        QC.questions.Remove(transform.gameObject);
        QC.indexes[QC.questionsAnswered] = questionIndex;
        QC.times.Add(System.DateTime.Now);
        QC.answers[QC.questionsAnswered] = choice;
        QC.questionsAnswered++;
        sfx.clip = outSound;
        Destroy(transform.gameObject, sfx.clip.length);
        sfx.Play();


    }

}
