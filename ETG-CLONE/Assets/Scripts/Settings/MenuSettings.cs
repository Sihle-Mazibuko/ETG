using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

#region Class Description:
/*
 * 
 */
#endregion

public class MenuSettings : MonoBehaviour
{
    #region Fields

    // Audio mixer component
    public AudioMixer audioMixer;
    
    #endregion

    #region Set volume
    
    //This function is called when we adjust the volume slider.
    public void SetMusicVolume (float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetAmbienceVolume (float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("SpatialVolume", volume);
    }
    
    public void SetSfxVolume (float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("SfxVolume", volume);
    }
    #endregion
}
