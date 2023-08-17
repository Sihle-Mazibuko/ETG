using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

#region Class Description:
/*
 *  This script loads the End Screen.
 */
#endregion

public class LoadEndScreen : MonoBehaviour
{
    #region Fields

    public string sfxName;
    public string sceneName;
    private GameObject _player;
    private UISceneLoader _sceneLoader;

    #endregion

    #region References

    private void Start()
    {
        // Get references.
        _player = GameObject.FindGameObjectWithTag("Player");
        _sceneLoader = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<UISceneLoader>();
    }
    #endregion

    #region Load End Screen

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check to see if Player is colliding with the volume
        if (col.gameObject == _player)
        {
            // Load scene
            StartCoroutine(Load());

            // Play SFX
            GlobalAudioPlayer.PlaySFX(sfxName);
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(3f);

       // Load completePanel screen
       _sceneLoader.LoadScene(sceneName);
    }
    #endregion
}
