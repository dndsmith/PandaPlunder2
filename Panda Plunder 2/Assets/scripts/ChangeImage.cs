using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeImage : MonoBehaviour
{
    public Sprite swapSprite;
    private Sprite incumbentSprite;
    private Image image;
    public bool isIncumbent = true;

    private void Awake()
    {
        image = GetComponent<Image>();
        incumbentSprite = image.sprite;
    }

    public void ChangeSprite()
    {
        if (!isIncumbent) image.sprite = incumbentSprite;
        else image.sprite = swapSprite;
        isIncumbent = !isIncumbent;
    }

    public void PermanentlyChangeSprite()
    {
        if (isIncumbent)
        {
            image.sprite = swapSprite;
            isIncumbent = false;
        }
    }
}
