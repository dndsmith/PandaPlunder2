using UnityEngine;
using UnityEngine.UI;
using System;

public class TutorialScreenMenuHandler : MainMenuHandler
{
    LoadingBar loadingBar;
    Button playButton;

    public float howLongToWaitToLoad;
    private bool firstGoRound = true;

    private void Start()
    {
        playButton = FindObjectOfType<Button>();
        playButton.interactable = false;
        loadingBar = FindObjectOfType<LoadingBar>();
        loadingBar.Loaded += C_OnLoaded;
    }

    private void Update()
    {
        if(firstGoRound)
        {
            loadingBar.BeginLoading(howLongToWaitToLoad);
            firstGoRound = false;
        }
    }

    public void C_OnLoaded(object sender, EventArgs e)
    {
        playButton.interactable = true;
    }
}
