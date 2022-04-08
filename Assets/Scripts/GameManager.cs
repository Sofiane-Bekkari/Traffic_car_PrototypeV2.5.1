using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public IEnumerator LoadGameOverScene ()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("GameOverScene");
    }

    public IEnumerator LoadWinningScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinningScene");
    }

    public void LoadNextLevel()
    {
        int nextLevelIndex = PlayerPrefs.GetInt("Last_Level") + 1;
        SceneManager.LoadScene(nextLevelIndex);
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
    }

    public void saveAsLastLevelPlayed()
    {
        PlayerPrefs.SetInt("Last_Level", SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LosingEvent()
    {
        saveAsLastLevelPlayed();
        StartCoroutine(LoadGameOverScene());
    }

    public void WinningEvent()
    {
        saveAsLastLevelPlayed();
        StartCoroutine(LoadWinningScene());
    }
}
