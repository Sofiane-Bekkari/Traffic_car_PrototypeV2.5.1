using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public IEnumerator LoadGameOverScene ()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("GameOverScene");
        SoundManager.Instance.ChangePitchMusic(0.3f);
    }

    public IEnumerator LoadWinningScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinningScene");
        SoundManager.Instance.ChangeVolumeInCase(0.1f); // VOLUME ON WINNING SCENE
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.ChangeVolumeInCase(0.3f); // VOLUME ON WINNING SCENE
    }

    public void LoadNextLevel()
    {
        int nextLevelIndex = PlayerPrefs.GetInt("Last_Level") + 1;
        SceneManager.LoadScene(nextLevelIndex);
        SoundManager.Instance.ChangeMusicVolume(PlayerPrefs.GetFloat("musicVolume")); // CHANGER IT BACK
    }

    public void LoadSelectLevelScene()
    {
        SceneManager.LoadScene("SelectLevelScene");
    }
    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Restart()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("Last_Level") ;
        SceneManager.LoadScene(lastLevelIndex);
        SoundManager.Instance.ChangeMusicVolume(PlayerPrefs.GetFloat("musicVolume")); // CHANGER IT BACK
        SoundManager.Instance.ChangePitchMusic(1f); // CHANGER IT BACK
    }

    public void loadLastLevelUnlocked()
    {
        int lastEvelUnlocked = PlayerPrefs.GetInt("Last_Level_unlocked");
        SceneManager.LoadScene(lastEvelUnlocked + 4);
    }
    public void loadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance.ChangePitchMusic(1f); // CHANGER IT BACK
    }

    void saveAsLastLevelPlayed()
    {
        PlayerPrefs.SetInt("Last_Level", SceneManager.GetActiveScene().buildIndex);   
    }
    void UnlockNextLevel()
    {
        int lastEvelUnlocked = PlayerPrefs.GetInt("Last_Level_unlocked");
        if(lastEvelUnlocked +4 == SceneManager.GetActiveScene().buildIndex )
        {
            PlayerPrefs.SetInt("Last_Level_unlocked", lastEvelUnlocked + 1);
        }
    }
    public void LosingEvent()
    {
        saveAsLastLevelPlayed();
        StartCoroutine(LoadGameOverScene());
    }

    public void WinningEvent()
    {
        saveAsLastLevelPlayed();
        UnlockNextLevel();
        StartCoroutine(LoadWinningScene());
    }
}
