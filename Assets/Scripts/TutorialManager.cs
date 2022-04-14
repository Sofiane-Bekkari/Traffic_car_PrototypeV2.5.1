using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUpTuto;
    public GameObject panelTuto;
    int indexPop = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(LoadTutorialPopUp()); // START TUTORIAL
 
    }

    public void NextPopUps()
    {
       indexPop++;
       if (indexPop == 1)
       {
            indexPop++;
            popUpTuto[0].SetActive(false);
            popUpTuto[1].SetActive(false);
            popUpTuto[2].SetActive(true);
            popUpTuto[3].SetActive(true);
            //Debug.Log("INDEX IS 1");
       }
       else if (indexPop == 3)
        {
            indexPop++;
            popUpTuto[0].SetActive(false);
            popUpTuto[2].SetActive(false);
            popUpTuto[3].SetActive(false);
            panelTuto.SetActive(false);
            Time.timeScale = 1f; // BACK TIME TO NORMAL
          //  Debug.Log("INDEX IS 3");

        }
      
    }
    public IEnumerator LoadTutorialPopUp()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0.05f; // PAUSE / SLOW DOWN TIME
        panelTuto.SetActive(true);
        popUpTuto[0].SetActive(true);
        popUpTuto[1].SetActive(true);
    }
}
