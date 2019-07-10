using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonHandler : MonoBehaviour
{

    public List<Sprite> starImages;
    public Image buttonImage;
    public Button settings;
    public Text score;

    void Awake()
    {
        buttonImage = GetComponent<Image>();
        settings = GetComponent<Button>();
    }
    public void setStars(int stars)
    {
        buttonImage.sprite = starImages[stars];
    }

    public void setScore(int inScore)
    {

        score.text = "Score: " + inScore.ToString();

    }

    public void turnOn()
    {
        settings.interactable = true;
    }
}