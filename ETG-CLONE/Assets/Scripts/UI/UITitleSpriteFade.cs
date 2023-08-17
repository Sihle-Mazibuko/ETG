using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Class Description:
/*
 * 
 */
#endregion

//fades a sprite until it becomes invisible
[RequireComponent(typeof(Sprite))]
public class UITitleSpriteFade : MonoBehaviour 
{
    #region Fields

    private float Delay = 3f;
	private float fadeTime = 4f;
	private bool restartAtFadeEnd = true;
	private Image image;
    #endregion

    #region Co-routines

    private void Start()
	{
		StartCoroutine(FadeIn());
	}

    IEnumerator FadeIn()
	{

        image = GetComponent<Image>();

		yield return new WaitForSeconds(Delay);
			
		float t = 3;
		while(t > 0) 
		{
			if (image)
			{
				image.color = new Color(1f, 1f, 1f, t);
			}

			t -= Time.deltaTime / fadeTime;
			yield return null;
		}

		image.color = new Color(1f, 1f, 1f, 0);

		if (restartAtFadeEnd)
		{
			StartCoroutine(FadeOut());
		}
	}
	
	IEnumerator FadeOut()
	{
		yield return new WaitForSeconds(Delay);

		image = GetComponent<Image>();

		if (restartAtFadeEnd)
		{
            StartCoroutine(FadeIn());
        }
	}
    #endregion
}
