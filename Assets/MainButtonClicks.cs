using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonClicks : MonoBehaviour
{
    public RectTransform pressedImage;
    public RectTransform[] rects;

    public void onClickMainButttons(int index)
    {
        StopAllCoroutines();
        int i = 0;

        foreach (RectTransform r in rects)
        {
            if (i + 1 == index)
            {
                StartCoroutine(ancorSlide(r, (float)i / 6f, (float)(i + 2) / 6f));
                i += 2;
            }
            else
            {
                StartCoroutine(ancorSlide(r, (float)i / 6f, (float)(i + 1) / 6f));
                i++;
            }
        }
    
        StartCoroutine(ancorSlide(pressedImage, ((float)index - 1f) * (1f / 6f), (((float)index - 1f) * (1f / 6f)) + (1f / 3f)));
    }

    IEnumerator ancorSlide(RectTransform ancorRect, float min, float max)
    {
        int step = 10;

        for (int i = 1; i <= step; i++)
        {
            ancorRect.anchorMin = new Vector2(ancorRect.anchorMin.x, Mathf.Lerp(ancorRect.anchorMin.y, min, (float)i / (float)step));
            ancorRect.anchorMax = new Vector2(ancorRect.anchorMax.x, Mathf.Lerp(ancorRect.anchorMax.y, max, (float)i / (float)step));

            yield return null;
        }

        ancorRect.anchorMin = new Vector2(ancorRect.anchorMin.x, min);
        ancorRect.anchorMax = new Vector2(ancorRect.anchorMax.x, max);
    }
}
