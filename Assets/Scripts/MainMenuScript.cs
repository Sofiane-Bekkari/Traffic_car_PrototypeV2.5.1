using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainContainerMenuUI;
    public GameObject settingContainerMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }

    // SETTING
    public void SettingOnMain()
    {
        settingContainerMenuUI.SetActive(true);
        mainContainerMenuUI.SetActive(false);
    }
    // BACK TO UPPER
    public void BackToUpper()
    {
        settingContainerMenuUI.SetActive(false);
        mainContainerMenuUI.SetActive(true);
    }
    // QUIT
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!");
    }
}
