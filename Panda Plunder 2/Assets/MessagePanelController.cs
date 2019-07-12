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
        HideMessage();
    }

    public static void Clear()
    {
        Instance.message.text = "";
    }

    public void DisplayMessage(string memo)
    {
        Instance.message.text = memo;
        Instance.MS.toView = true;
    }

    public static void DisplayMessage(string memo, float time)
    {
        Instance.StartCoroutine(Instance.TimedDisplay(memo, time));
    }

    public void HideMessage()
    {
        Instance.MS.toView = false;
    }

    IEnumerator TimedDisplay(string memo, float time)
    {
        DisplayMessage(memo);
        stopwatch.Start();
        while(stopwatch.Elapsed.TotalSeconds < time)
        {
            yield return 0;
        }
        stopwatch.Reset();
        HideMessage();
    }
}
