using UnityEngine;

#region Class Description:
/*
 *  This script plays a track on Start.
 */
#endregion

public class PlayMusic : MonoBehaviour
{
    public string musicName;

    private void Start()
    {
        GlobalAudioPlayer.PlayMusic(musicName);
    }
}
