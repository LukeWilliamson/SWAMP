using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour 
{
    [HideInInspector]
	public AudioClip music;

    [HideInInspector]
    public AudioSource source;

	public static AudioManager playing;

	void Start () 
	{
		source = GetComponent<AudioSource>();
		music = source.clip;

		if(playing != null && playing != this)
		{
			if(music != playing.music)
			{
				StartCoroutine(CrossFade());
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			source.Play();
			playing = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public IEnumerator CrossFade ()
	{
		while(playing.source.volume > 0)
		{
			playing.source.volume -= 0.005f;
			yield return null;
		}

		Destroy(playing.gameObject);

		playing = this;

		source.Play();
		source.volume = 0;
		while(source.volume < 1)
		{
			source.volume += 0.005f;
			yield return null;
		}
	}

    public void FadeOut()
    {
        StartCoroutine(FadeOutMusic());
    }

    public IEnumerator FadeOutMusic()
    {
        while (source.volume > 0)
        {
            playing.source.volume -= 0.05f;
            yield return null;
        }
        source.Stop();
        source.volume = 1;
    }
}
