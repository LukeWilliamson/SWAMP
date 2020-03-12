using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    private void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }

        }
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void quit()
    {
        Application.Quit();
    }
}
