using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{   
    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    public Button[] pauseMenuButton;
    public string[] pauseMenuButtonText;
    [HideInInspector]
    public int pauseButtonIndex = 0;

    [Header("Options Menu")]
    public GameObject optionsMenuUI;
    public Button[] optionsMenuButton;
    public string[] optionsMenuButtonText;
    [HideInInspector]
    public int optionsButtonIndex = 0;

    [Header("Audio Menu")]
    public GameObject audioMenuUI;
    public RectTransform[] audioMenuButton;
    public GameObject audioMenuIndicator;
    public Slider[] audioSlider;
    public Image[] audioSliderHandle;
    public Image[] audioSliderFill;
    public Image[] audioSliderBackground;
    [HideInInspector]
    public int audioButtonIndex = 0;
    [Space(10)]
    public AudioMixer mixer;

    [Header("Input Menu")]
    public GameObject inputMenuUI;
    public Button[] inputMenuButton;
    //[HideInInspector]
    public int inputButtonIndex = 0;

    private void Start()
    {
        Stats.isPaused = false;

        for (int i = 0; i < pauseMenuButton.Length; i++)
        {
            pauseMenuButton[i].GetComponentInChildren<Text>().text = pauseMenuButtonText[i];
        }

        for (int i = 0; i < optionsMenuButton.Length; i++)
        {
            optionsMenuButton[i].GetComponentInChildren<Text>().text = optionsMenuButtonText[i];
        }
    }
    void Update()
    {
        CycleButtons();

        if (InputManager.PressPause())
        {
            if (Stats.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (InputManager.PressJump())
        {
            // Pause Menu Commands
            if (pauseButtonIndex == 0 && pauseMenuUI.activeSelf)
            {
                Resume();
            }
            else if (pauseButtonIndex == 1 && pauseMenuUI.activeSelf)
            {
                Options();
            }
            else if (pauseButtonIndex == 2 && pauseMenuUI.activeSelf)
            {
                MainMenu();
            }

            // Options Menu Commands
            else if (optionsButtonIndex == 0 && optionsMenuUI.activeSelf)
            {
                Audio();
            }
            else if (optionsButtonIndex == 1 && optionsMenuUI.activeSelf)
            {
                Input();
            }
            else if (optionsButtonIndex == 2 && optionsMenuUI.activeSelf)
            {
                Return();
            }

            // Audio Menu Commands
            else if (audioButtonIndex == 3 && audioMenuUI.activeSelf)
            {
                Options();
            }

            // Input Menu Commands
            else if (inputButtonIndex == 12 && inputMenuUI.activeSelf)
            {
                FindObjectOfType<InputMapper>().RestoreToDefaults();
            }
            else if (inputButtonIndex == 13 && inputMenuUI.activeSelf)
            {
                Options();
            }
        }

        if (FindObjectOfType<InputMapper>())
        {
            if (InputManager.PressJump() && !FindObjectOfType<InputMapper>().listening)
            {
                // Input Menu Commands
                if (inputButtonIndex == 0 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeRight();
                }
                else if (inputButtonIndex == 1 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeLeft();
                }
                else if (inputButtonIndex == 2 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeHorizontal();
                }
                else if (inputButtonIndex == 3 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeUp();
                }
                else if (inputButtonIndex == 4 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeDown();
                }
                else if (inputButtonIndex == 5 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeVertical();
                }
                else if (inputButtonIndex == 6 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeJump();
                }
                else if (inputButtonIndex == 7 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeAttack();
                }
                else if (inputButtonIndex == 8 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeDash();
                }
                else if (inputButtonIndex == 9 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeCrouch();
                }
                else if (inputButtonIndex == 10 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangePause();
                }
                else if (inputButtonIndex == 11 && inputMenuUI.activeSelf)
                {
                    FindObjectOfType<InputMapper>().acceptInput = true;
                    FindObjectOfType<InputMapper>().ChangeMap();
                }
            }
        }

        if (audioButtonIndex != audioMenuButton.Length - 1 && audioMenuUI.activeSelf && InputManager.HoldHorizontal() > 0)
        {
            audioSlider[audioButtonIndex].value += 0.02f;
        }
        else if(audioButtonIndex != audioMenuButton.Length - 1 && audioMenuUI.activeSelf && InputManager.HoldHorizontal() < 0)
        {
            audioSlider[audioButtonIndex].value -= 0.02f;
        }

        if(audioButtonIndex != audioMenuButton.Length - 1)
        {
            audioMenuIndicator.SetActive(true);
            audioMenuIndicator.transform.SetParent(audioMenuButton[audioButtonIndex].transform);
            audioMenuIndicator.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            audioMenuButton[audioMenuButton.Length - 1].GetComponentInChildren<Text>().text = "Return";
        }
        else
        {
            audioMenuButton[audioButtonIndex].GetComponentInChildren<Text>().text = "- Return -";
            audioMenuIndicator.SetActive(false);
        }
    }

    public void CycleButtons()
    {
        if (InputManager.PressVertical() < 0)
        {
            pauseButtonIndex += 1;
            optionsButtonIndex += 1;
            audioButtonIndex += 1;
        }

        if (InputManager.PressVertical() > 0)
        {
            pauseButtonIndex -= 1;
            optionsButtonIndex -= 1;
            audioButtonIndex -= 1;
        }

        if (pauseButtonIndex > pauseMenuButton.Length - 1)
        {
            pauseButtonIndex = 0;
            optionsButtonIndex = 0;
        }

        if (pauseButtonIndex < 0)
        {
            pauseButtonIndex = pauseMenuButton.Length - 1;
            optionsButtonIndex = optionsMenuButton.Length - 1;
        }

        //Reset Audio Buttons
        if (audioButtonIndex > audioMenuButton.Length - 1)
        {
            audioButtonIndex = 0;
        }

        if (audioButtonIndex < 0)
        {
            audioButtonIndex = audioMenuButton.Length - 1;
        }

        ChangeInputValue();

        for (int i = 0; i < pauseMenuButton.Length; i++)
        {
            pauseMenuButton[i].GetComponentInChildren<Text>().text = pauseMenuButtonText[i];
            pauseMenuButton[i].GetComponentInChildren<Text>().color = Color.gray;
        }

        for (int i = 0; i < optionsMenuButton.Length; i++)
        {
            optionsMenuButton[i].GetComponentInChildren<Text>().text = optionsMenuButtonText[i];
            optionsMenuButton[i].GetComponentInChildren<Text>().color = Color.gray;
        }

        for (int i = 0; i < audioMenuButton.Length; i++)
        {
            audioMenuButton[i].GetComponentInChildren<Text>().color = Color.gray;
        }

        for (int i = 0; i < inputMenuButton.Length; i++)
        {
            if (i < inputMenuButton.Length - 2)
            {
                inputMenuButton[i].GetComponentInChildren<Image>().color = Color.gray;
            }

            foreach (Text title in inputMenuButton[i].GetComponentsInChildren<Text>())
            {
                title.color = Color.gray;
            }
        }

        for (int i = 0; i < audioSliderFill.Length; i++)
        {
            audioSliderFill[i].color = Color.gray;
            audioSliderHandle[i].color = Color.gray;
        }

        for (int i = 0; i < audioSliderBackground.Length; i++)
        {
            audioSliderBackground[i].color = new Color(0.35f, 0.35f, 0.35f, 1);
        }

        pauseMenuButton[pauseButtonIndex].GetComponentInChildren<Text>().text = "- " + pauseMenuButtonText[pauseButtonIndex] + " -";
        pauseMenuButton[pauseButtonIndex].GetComponentInChildren<Text>().color = Color.white;

        optionsMenuButton[optionsButtonIndex].GetComponentInChildren<Text>().text = "- " + optionsMenuButtonText[optionsButtonIndex] + " -";
        optionsMenuButton[optionsButtonIndex].GetComponentInChildren<Text>().color = Color.white;

        audioMenuButton[audioButtonIndex].GetComponentInChildren<Text>().color = Color.white;

        if (audioButtonIndex != audioMenuButton.Length - 1)
        {
            audioSliderHandle[audioButtonIndex].color = Color.white;
            audioSliderFill[audioButtonIndex].color = Color.white;
            audioSliderBackground[audioButtonIndex].color = new Color(0.85f, 0.85f, 0.85f, 1);
        }

        if (inputButtonIndex < inputMenuButton.Length - 2)
        {
            inputMenuButton[inputButtonIndex].GetComponentInChildren<Image>().color = Color.white;
        }

        foreach (Text title in inputMenuButton[inputButtonIndex].GetComponentsInChildren<Text>())
        {
            title.color = Color.white;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        inputMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        Stats.isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        inputMenuUI.SetActive(false);
        Time.timeScale = 0.0f;
        Stats.isPaused = true;

        pauseButtonIndex = 0;
        optionsButtonIndex = 0;
        audioButtonIndex = 0;
        CycleButtons();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Options ()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        audioMenuUI.SetActive(false);
        inputMenuUI.SetActive(false);

        pauseButtonIndex = 0;
        optionsButtonIndex = 0;
        audioButtonIndex = 0;
        CycleButtons();
    }

    public void Audio()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(true);
        inputMenuUI.SetActive(false);

        pauseButtonIndex = 0;
        optionsButtonIndex = 0;
        audioButtonIndex = 0;
        CycleButtons();
    }

    public void Input()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        inputMenuUI.SetActive(true);

        pauseButtonIndex = 0;
        optionsButtonIndex = 0;
        audioButtonIndex = 0;
        inputButtonIndex = 12;
        CycleButtons();
    }

    public void Return()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        inputMenuUI.SetActive(false);

        pauseButtonIndex = 1;
        optionsButtonIndex = 1;
        audioButtonIndex = 1;
        CycleButtons();
    }

    public void SetMusicVolume (float val)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(val) * 20);
    }

    public void SetSFXVolume(float val)
    {
        mixer.SetFloat("SoundVolume", Mathf.Log10(val) * 20);
    }

    public void SetMasterVolume(float val)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(val) * 20);
    }

    public void ChangeInputValue ()
    {
        if (!InputManager.HoldJump() && FindObjectOfType<InputMapper>())
        {
            if (!FindObjectOfType<InputMapper>().horizontalButton.gameObject.activeSelf && !FindObjectOfType<InputMapper>().verticalButton.gameObject.activeSelf)
            {
                if (inputButtonIndex == 2)
                {
                    inputButtonIndex = 0;
                    return;
                }

                if (inputButtonIndex == 5)
                {
                    inputButtonIndex = 3;
                    return;
                }

                if (InputManager.PressHorizontal() > 0)
                {
                    if (inputButtonIndex == 0)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 11;
                        return;
                    }
                }

                if (InputManager.PressHorizontal() < 0)
                {
                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 0;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 4;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 8;
                        return;
                    }
                }

                if (InputManager.PressVertical() > 0)
                {
                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 0;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 13)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }

                if (InputManager.PressVertical() < 0)
                {
                    if (inputButtonIndex == 0)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 4;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 13;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }
            }
            else if(!FindObjectOfType<InputMapper>().horizontalButton.gameObject.activeSelf && FindObjectOfType<InputMapper>().verticalButton.gameObject.activeSelf)
            {
                if (inputButtonIndex == 3 || inputButtonIndex == 4)
                {
                    inputButtonIndex = 5;
                    return;
                }

                if (InputManager.PressHorizontal() > 0)
                {
                    if (inputButtonIndex == 0)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 11;
                        return;
                    }
                }

                if (InputManager.PressHorizontal() < 0)
                {
                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 0;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 8;
                        return;
                    }
                }

                if (InputManager.PressVertical() > 0)
                {
                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 0;
                        return;
                    }

                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 13)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }

                if (InputManager.PressVertical() < 0)
                {
                    if (inputButtonIndex == 0)
                    {
                        inputButtonIndex = 1;
                        return;
                    }

                    if (inputButtonIndex == 1)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 4;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 13;
                        return;
                    }

                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }
            }
            else if (FindObjectOfType<InputMapper>().horizontalButton.gameObject.activeSelf && !FindObjectOfType<InputMapper>().verticalButton.gameObject.activeSelf)
            {
                if (inputButtonIndex == 0 || inputButtonIndex == 1)
                {
                    inputButtonIndex = 2;
                    return;
                }

                if (InputManager.PressHorizontal() > 0)
                {
                    if (inputButtonIndex == 2)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 11;
                        return;
                    }
                }

                if (InputManager.PressHorizontal() < 0)
                {
                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 4;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 8;
                        return;
                    }
                }

                if (InputManager.PressVertical() > 0)
                {
                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 13)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }

                if (InputManager.PressVertical() < 0)
                {
                    if (inputButtonIndex == 2)
                    {
                        inputButtonIndex = 3;
                        return;
                    }

                    if (inputButtonIndex == 3)
                    {
                        inputButtonIndex = 4;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 13;
                        return;
                    }

                    if (inputButtonIndex == 4)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }
            }
            else if (FindObjectOfType<InputMapper>().horizontalButton.gameObject.activeSelf && FindObjectOfType<InputMapper>().verticalButton.gameObject.activeSelf)
            {
                if (inputButtonIndex == 0 || inputButtonIndex == 1)
                {
                    inputButtonIndex = 2;
                    return;
                }

                if (inputButtonIndex == 3 || inputButtonIndex == 4)
                {
                    inputButtonIndex = 5;
                    return;
                }

                if (InputManager.PressHorizontal() > 0)
                {
                    if (inputButtonIndex == 2)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 11;
                        return;
                    }
                }

                if (InputManager.PressHorizontal() < 0)
                {
                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 8;
                        return;
                    }
                }

                if (InputManager.PressVertical() > 0)
                {
                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 2;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 6;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 10;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 13)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }

                if (InputManager.PressVertical() < 0)
                {
                    if (inputButtonIndex == 2)
                    {
                        inputButtonIndex = 5;
                        return;
                    }

                    if (inputButtonIndex == 6)
                    {
                        inputButtonIndex = 7;
                        return;
                    }

                    if (inputButtonIndex == 7)
                    {
                        inputButtonIndex = 8;
                        return;
                    }

                    if (inputButtonIndex == 8)
                    {
                        inputButtonIndex = 9;
                        return;
                    }

                    if (inputButtonIndex == 9)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 10)
                    {
                        inputButtonIndex = 11;
                        return;
                    }

                    if (inputButtonIndex == 12)
                    {
                        inputButtonIndex = 13;
                        return;
                    }

                    if (inputButtonIndex == 5)
                    {
                        inputButtonIndex = 12;
                        return;
                    }

                    if (inputButtonIndex == 11)
                    {
                        inputButtonIndex = 12;
                        return;
                    }
                }
            }
        }
    }
}
