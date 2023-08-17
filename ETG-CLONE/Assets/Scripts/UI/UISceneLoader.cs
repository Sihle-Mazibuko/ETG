using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Class Description:
/*
 *  This script handles all scene management functions.
 */
#endregion

public class UISceneLoader : MonoBehaviour 
{
	#region Fields

	#region Private Fields:

	private bool loadSceneInProgress;

    #endregion

    #endregion

    #region Load a new scene

    // This function will load a new scene by taking in the scene index
    public void LoadScene(string sceneName)
	{
		if (!loadSceneInProgress)
		{
			StartCoroutine(LoadSceneCoroutine(sceneName));
		}
	}
    #endregion

    #region Exit game

    // This funtion will close the program
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("You exited game!");
    }
    #endregion

    #region Co-routines

    IEnumerator LoadSceneCoroutine(string sceneName)
	{
		loadSceneInProgress = true;

		//Fade out screen
		UIFader fader = GameObject.FindObjectOfType<UIFader>();

		if (fader != null)
		{
			fader.Fade(UIFader.FADE.FadeOut, 0.4f, 0.4f);
		}

		yield return new WaitForSeconds(0.8f);

		//Load new scene
		SceneManager.LoadScene(sceneName);

		loadSceneInProgress = false;
	}
    #endregion
}
