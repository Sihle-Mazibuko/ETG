using UnityEngine;

namespace PointAndClick 
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioPlayer : MonoBehaviour 
	{
		#region Fields

		#region Public Fields:

		public AudioItem[] AudioList;
		#endregion

		#region Private Fields:

		private AudioSource audioSource;
		private float musicVolume = 1f;
		private float sfxVolume = 1f;
        #endregion

        #endregion

        #region References and settings

        private void Awake()
		{
			// Get references.
			GlobalAudioPlayer.audioPlayer = this;
			audioSource = GetComponent<AudioSource>();

			// Set settings. 
			GameSettings settings = Resources.Load("GameSettings", typeof(GameSettings)) as GameSettings;

			if (settings != null)
			{
				musicVolume = settings.MusicVolume;
				sfxVolume = settings.SFXVolume;
			}
		}
        #endregion

        #region Play a sfx

        // Play a projectileHitSFX.
        public void playSFX(string name)
		{
			bool SFXFound = false;

			foreach (AudioItem audioItem in AudioList)
			{
				if (audioItem.name == name)
				{
					// Pick a random number (not same twice).
					int rand = Random.Range (0, audioItem.clip.Length);
					audioSource.PlayOneShot(audioItem.clip[rand]);
					audioSource.volume = audioItem.volume * sfxVolume;
					audioSource.loop = audioItem.loop;
					SFXFound = true;
				}
			}

			if (!SFXFound)
			{
				Debug.Log("no SFX found with name: " + name);
			}
		}

		// Plays a projectileHitSFX at a certain world position.
		public void playSFXAtPosition(string name, Vector3 worldPosition, Transform parent)
		{
			bool SFXFound = false;

			foreach (AudioItem audioItem in AudioList)
			{
				if (audioItem.name == name)
				{
					// Check the time threshold.
					if (Time.time - audioItem.lastTimePlayed < audioItem.MinTimeBetweenCall)
					{
						return;
					} 
					else 
					{
						audioItem.lastTimePlayed = Time.time;
					}

					// Pick a random number.
					int rand = Random.Range (0, audioItem.clip.Length);

					// Create gameobject for the audioSource.
					GameObject audioObj = new GameObject ();
					audioObj.transform.parent = parent;
					audioObj.name = name;
					audioObj.transform.position = worldPosition;
					AudioSource audiosource = audioObj.AddComponent<AudioSource>();

					// Audio source settings.
					audiosource.clip = audioItem.clip[rand];
					audiosource.spatialBlend = 1.0f;
					audiosource.minDistance = 4f;
					audiosource.volume = audioItem.volume * sfxVolume;
					audiosource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
					audiosource.loop = audioItem.loop;
					audiosource.Play ();

					// Destroy on finish.
					if (!audioItem.loop && audiosource.clip != null) 
					{ 
						TimeToLive TTL = audioObj.AddComponent<TimeToLive> ();
						TTL.LifeTime = audiosource.clip.length;
					}

					SFXFound = true;
				}
			}

			if (!SFXFound)
			{
				Debug.Log("no projectileHitSFX found with name: " + name);
			}
		}

		public void playSFXAtPosition(string name, Vector3 worldPosition)
		{
			playSFXAtPosition (name, worldPosition, transform.root);
		}
        #endregion

        #region Play music

        public void playMusic(string name)
		{
			// Create a separate gameobject designated for playing music.
			GameObject music = new GameObject();
			music.name = "Music";
			AudioSource audioSource = music.AddComponent<AudioSource>();

			// Get music track from trackList.
			foreach (AudioItem audioItem in AudioList)
			{
				if (audioItem.name == name)
				{
					audioSource.clip = audioItem.clip[0];
					audioSource.loop = true;
					audioSource.volume = audioItem.volume * musicVolume;
					audioSource.Play();
				}
			}
		}
		#endregion
	}   
}
