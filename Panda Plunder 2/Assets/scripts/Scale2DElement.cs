using UnityEngine;
using System.Collections;

// Game 2
// NOT USED

/*
 *  Don't bother, but at the time I was trying to scale 2D elements up or down.
 */

[RequireComponent(typeof(RectTransform))]
public class Scale2DElement : MonoBehaviour
{
    RectTransform RT;

    private void Start()
    {
        RT = GetComponent<RectTransform>();
    }
    /*public IEnumerator ScaleElement(Vector2 startSize, Vector2 endSize, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            RT.sizeDelta = new ;
            yield return 0;
        }
    }*/
}
