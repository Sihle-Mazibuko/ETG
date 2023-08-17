using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class Description:
/*
 *  This script automatically loads a scene.
 */
#endregion

public class AutoUISceneLoader : MonoBehaviour
{
    #region Fields

    public string sceneName;
    public bool autoStart;
    public float waitTime;
    private UISceneLoader _sceneLoader;

    #endregion

    #region Load scene
    private void Start()
    {
        // Get references.
        _sceneLoader = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<UISceneLoader>();

        if (autoStart)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitTime);

        // Load completePanel screen
        _sceneLoader.LoadScene(sceneName);
    }
    #endregion
}
