using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanelController : MonoBehaviour
{
    // Singleton
    private static MessagePanelController instance;
    public static MessagePanelController Instance { get { return instance; } private set {} }

    moveScore MS;
    Text message;
    Image image;
    Stopwatch stopwatch = new Stopwatch();

    // set Singleton
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MS = GetComponent<moveScore>();
        message = GetComponentInChildren<Text>();
        image = GetComponentsInChildren<Image>()[1];
        HideMessage();
    }

    public static void Clear()
    {
        Instance.message.text = "";
    }

    public void DisplayMessage(string memo)
    {
        image.enabled = false;
        Instance.message.text = memo;
        Instance.MS.toView = true;
    }

    public void DisplayMessage(string memo, Sprite sprite)
    {
        if (sprite == null) image.enabled = false;
        Instance.message.text = memo;
        Instance.image.sprite = sprite;
        Instance.MS.toView = true;
    }

    public static void DisplayMessage(string memo, float time)
    {
        Instance.StartCoroutine(Instance.TimedDisplay(memo, time));
    }

    public static void DisplayMessage(string memo, Sprite sprite, float time)
    {
        Instance.StartCoroutine(Instance.TimedDisplay(memo, sprite, time));
    }

    static public void HideMessage()
    {
        Instance.MS.toView = false;
    }

    IEnumerator TimedDisplay(string memo, float time)
    {
        if(stopwatch.Elapsed.TotalSeconds > 0)
        {
            stopwatch.Reset();
            HideMessage();
        }
        stopwatch.Start();
        DisplayMessage(memo);
        while (stopwatch.Elapsed.TotalSeconds < time)
        {
            yield return 0;
        }
        stopwatch.Reset();
        HideMessage();
    }

    IEnumerator TimedDisplay(string memo, Sprite sprite, float time)
    {
        if (stopwatch.Elapsed.TotalSeconds > 0)
        {
            stopwatch.Reset();
            HideMessage();
        }
        stopwatch.Start();
        DisplayMessage(memo, sprite);
        while (stopwatch.Elapsed.TotalSeconds < time)
        {
            yield return 0;
        }
        stopwatch.Reset();
        HideMessage();
    }
}
