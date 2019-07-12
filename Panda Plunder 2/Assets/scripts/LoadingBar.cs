using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections;

public class LoadingBar : MonoBehaviour
{
    public event EventHandler<EventArgs> Loaded;
    ChangeImage[] circles;
    Stopwatch stopwatch = new Stopwatch();
    
    void Start()
    {
        circles = GetComponentsInChildren<ChangeImage>();
    }

    public void BeginLoading(float interval)
    {
        StartCoroutine(Loading(interval));
    }

    IEnumerator Loading(float interval)
    {
        float increment = interval / circles.Length;
        int i = 1;
        stopwatch.Start();
        while(stopwatch.Elapsed.TotalSeconds < interval)
        {
            if(stopwatch.Elapsed.TotalSeconds > increment * i)
            {
                circles[i - 1].PermanentlyChangeSprite();
                i++;
            }
            yield return 0;
        }
        stopwatch.Reset();
        circles[i - 1].PermanentlyChangeSprite();
        EventArgs e = new EventArgs();
        OnLoaded(e);
    }

    protected virtual void OnLoaded(EventArgs e)
    {
        Loaded?.Invoke(this, e);
    }
}
