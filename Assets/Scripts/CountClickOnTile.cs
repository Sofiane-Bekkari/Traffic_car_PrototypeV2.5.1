using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountClickOnTile : MonoBehaviour
{
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        Debug.Log("FIRST START ON: " + counter);
    }
    public void CounterClick(bool isCount)
    {
        if (isCount)
        {
            counter++;
            Debug.Log("On CountClickOnTile: " + counter);
            PlayerPrefs.SetInt("ClickOnTile", counter);
            PlayerPrefs.Save();

        }
    }
}
