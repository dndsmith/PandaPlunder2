using UnityEngine;
using System.Collections;

public class Move2DElement : MonoBehaviour
{
    public IEnumerator MoveElement(Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return 0;
        }
    }
}
