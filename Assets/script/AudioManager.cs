using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public enum AudioChannel {volumen,MUTE,musica};
	public float Volumen { get; private set;}
	public float MuteAudio {get; private set;}
	public float Music {get; private set;}

	private AudioClip[] terreno;

	AudioSource[]MusicSource;
	int activeMusicSourceIndex;

	public static AudioManager instance;


	void Awake ()
	{
		instance = this;

		MusicSource = new AudioSource [2];
		for (int i = 0; i < 2; i++) 
		{
			GameObject newMusicSource = new GameObject ("Music Source" + (i + 1));
			MusicSource[i] = newMusicSource.AddComponent<AudioSource> ();
			newMusicSource.transform.parent = transform;
		}

		Volumen = PlayerPrefs.GetFloat ("Volumen",1);
		MuteAudio = PlayerPrefs.GetFloat ("MuteAudio", 1);
		Music = PlayerPrefs.GetFloat ("Music",1);
	}
	public void PlayMusic(AudioClip clip, float fadeDuration = 1)
	{
		activeMusicSourceIndex = 1 - activeMusicSourceIndex;
		MusicSource [activeMusicSourceIndex].clip = clip;
		MusicSource [activeMusicSourceIndex].Play ();

		StartCoroutine (AnimateMusicCrossfade (fadeDuration));
	}
	public void PlaySound(AudioClip clip, Vector3 pos)
	{
		AudioSource.PlayClipAtPoint (clip, pos, Volumen * MuteAudio);
	}
	IEnumerator AnimateMusicCrossfade(float duration)
	{
		float percent = 0;
		while (percent < 1)
		{
			percent += Time.deltaTime * 1 / duration;
			MusicSource [activeMusicSourceIndex].volume = Mathf.Lerp (0, Music * Volumen, percent);
			MusicSource [1-activeMusicSourceIndex].volume = Mathf.Lerp ( Music * Volumen,0, percent);
			yield return null;
		}
	}
}
