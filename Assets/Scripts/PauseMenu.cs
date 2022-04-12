using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject subPauseMenuUI;
    public GameObject settingMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) // IF ALREADY PAUSED
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    // RESUME
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }
    // PAUSE
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    // GO TO MAIN MENU
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // SETTING
    public void Setting()
    {
        subPauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(true);
    }
    // BACK TO UPPER
    public void BackToUpper()
    {
        subPauseMenuUI.SetActive(true);
        settingMenuUI.SetActive(false);
    }
}
