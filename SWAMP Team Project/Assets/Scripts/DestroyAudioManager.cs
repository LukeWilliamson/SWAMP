using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioManager : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<AudioManager>())
        {
            Destroy(FindObjectOfType<AudioManager>().gameObject);
        }
    }

    private void Update()
    {
        if(InputManager.PressPause())
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #endif

            Application.Quit();
        }
    }
}
