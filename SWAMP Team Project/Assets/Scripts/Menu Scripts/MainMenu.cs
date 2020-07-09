using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    [Space(10)]
    public Image blackScreen;
    public AudioSource aud;
    bool fade = false;

    private void Update()
    {
        if(InputManager.PressJump())
        {
            Play();
        }

        if (fade)
        {
            blackScreen.color = Color.Lerp(blackScreen.color, Color.black, Time.deltaTime * 2);
            aud.volume = Mathf.Lerp(aud.volume, 0, Time.deltaTime);
        }

        if(blackScreen.color == Color.black)
        {
            Stats.playerHealth = Stats.maxPlayerHealth;
            Stats.respawning = true;
            SceneManager.LoadScene(Stats.currentWorkbenchScene);
        }
    }

    public void Play()
    {
        fade = true;
        Time.timeScale = 1f;
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void Return()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
