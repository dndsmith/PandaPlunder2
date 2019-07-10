using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storySlides : MonoBehaviour {

    public List<Texture2D> images;
    public gameData GD;
    public RawImage currentImage;
    public int index;

	// Use this for initialization

    void Start () {

        GD = FindObjectOfType<gameData>();
        index = 0;
        currentImage.texture = images[index];

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(index < images.Count - 1)
            {
                index++;
                currentImage.texture = images[index];

            }
            else
            {
                GD.LoadScene("Menus/levelSelect");
                GD.PI.levelLock++;
                GD.SavePlayer();

            }

        }
	
	}
}
