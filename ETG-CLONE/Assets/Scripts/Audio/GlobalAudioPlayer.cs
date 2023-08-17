using UnityEngine;

#region Class Description:
/*
 *  This script handles all audio functions.
 */
#endregion

public static class GlobalAudioPlayer 
{
    #region Fields

    public static PointAndClick.AudioPlayer audioPlayer;
    #endregion

    #region Play a sfx
    public static void PlaySFX(string sfxName)
	{
		if (audioPlayer != null && sfxName != "")
		{
			audioPlayer.playSFX(sfxName);
        }
	}

	public static void PlaySFXAtPosition(string sfxName, Vector3 position)
	{
		if (audioPlayer != null && sfxName != "")
		{
			audioPlayer.playSFXAtPosition(sfxName, position);
		}
	}

	public static void PlaySFXAtPosition(string sfxName, Vector3 position, Transform parent)
	{
		if (audioPlayer != null && sfxName != "")
		{
			audioPlayer.playSFXAtPosition(sfxName, position, parent);
		}
	}
    #endregion

    #region Play music
    public static void PlayMusic(string musicName)
	{
		if (audioPlayer != null)
		{
			audioPlayer.playMusic(musicName);
		}
	}
    #endregion
}
