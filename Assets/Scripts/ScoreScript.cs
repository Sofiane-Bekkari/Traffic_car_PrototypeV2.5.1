using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI toatCarsTxt;
    //public TextMeshProUGUI toatClickTxt;
    int carsLeft = 0;
    int carsNoneSpawn;

    void Start()
    {
        carsNoneSpawn = GameObject.FindGameObjectsWithTag("Car").Length; // GET NUMBER OF CAR
        //int getNumClick = PlayerPrefs.GetInt("ClickOnTile");
        //toatClickTxt.text = "" + getNumClick;

        carsLeft = CarSpawner.numberOfCars;
        if ( carsLeft > 0) // IF THERE CAR FROM SPAWNER
        {
            toatCarsTxt.text = "" + CarSpawner.numberOfCars;
        }
        else if ( carsLeft == 0) // IF THERE NONE CAR FROM SPAWNER
        {
            toatCarsTxt.text = "" + carsNoneSpawn;
        }
    }
    public void UpdateScore()
    {
        if ( carsLeft > 0) // IF THERE CAR FROM SPAWNER
        {
            carsLeft--;
            toatCarsTxt.text = " " + carsLeft;
            if (carsLeft == 0)
            {
                FindObjectOfType<GameManager>().WinningEvent();
            }
        }
        else // IF THERE NONE CAR FROM SPAWNER
        {
            carsNoneSpawn--;
            toatCarsTxt.text = " " + carsNoneSpawn;
            if (carsNoneSpawn == 0)
            {
                FindObjectOfType<GameManager>().WinningEvent();
            }
        }
    }
}
