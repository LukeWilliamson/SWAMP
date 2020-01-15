using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SliderType
{
	Master,
	Music,
	Sounds
}

public class PauseMenu : MonoBehaviour
{
	[Header ("Audio")]
	public bool audio;
	public SliderType audioType;
	public AudioMixer mixer;

	[Header ("Button")]
	public string sceneToLoad;

	void Start ()
	{
		if(audio)
		{
			if(audioType == SliderType.Master)
			{
				GetComponent<Slider>().value = Stats.masterVolume;
			}

			if(audioType == SliderType.Music)
			{
				GetComponent<Slider>().value = Stats.musicVolume;
			}

			if(audioType == SliderType.Sounds)
			{
				GetComponent<Slider>().value = Stats.soundVolume;
			}
		}
	}

	public void LoadScene ()
	{
		SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
	}

	public void SetVolume (float sliderValue)
	{
		if(audioType == SliderType.Master)
		{
			mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
			Stats.masterVolume = GetComponent<Slider>().value;
		}

		if(audioType == SliderType.Music)
		{
			mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
			Stats.musicVolume = GetComponent<Slider>().value;
		}

		if(audioType == SliderType.Sounds)
		{
			mixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
			Stats.soundVolume = GetComponent<Slider>().value;
		}
	}
}
