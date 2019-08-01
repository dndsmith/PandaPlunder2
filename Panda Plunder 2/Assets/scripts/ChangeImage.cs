using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Game 2

/*
 *  Changes the Sprite of a 2D image between a set of 2 sprites.
 *  Used by the add/subtract buttons in the Assignment Menu.
 */
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
