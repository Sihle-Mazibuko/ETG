using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//fades a sprite until it becomes invisible
[RequireComponent(typeof(Text))]
public class UITextFade : MonoBehaviour
{
    private float Delay = .5f;
    private float fadeTime = 3f;
    private bool destroyAtFadeEnd = true;
    private Text text;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        text = GetComponent<Text>();

        float t = 1;
        while (t > 0)
        {
            if (text)
            {
                text.color = new Color(1f, 1f, 1f, t);
            }

            t -= Time.deltaTime / fadeTime;
            yield return null;
        }

        text.color = new Color(1f, 1f, 1f, 0);
        if (destroyAtFadeEnd)
        {
            Destroy(gameObject);
        }
    }
}
