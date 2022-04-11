using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    
    public Text carsTotalTxt;
    public Text numberOfCarsVariantTxt;
    public Text numberOfPointsVariantTxt;
     public SpawnDetails spawnDetails;

    public void Generate()
    {
        
        EditorUtility.SetDirty(spawnDetails);

        // store value from inpuFiels to variables
        int numberOfCarsToSpawn = int.Parse(carsTotalTxt.text);
        int numberOfCarsVariant = int.Parse(numberOfCarsVariantTxt.text);
        int numberOfPointsVariant = int.Parse(numberOfPointsVariantTxt.text);

        //clear data if exists from scriptableObject
        spawnDetails.spawnOrder.Clear();
        spawnDetails.carsOrder.Clear();

        //generate and fill scriptableObject data
        spawnDetails.totalCarsNumber = numberOfCarsToSpawn;
        for (int i = 0; i < numberOfCarsToSpawn; i++)
        {
            int randIntForCars = Random.Range(0, numberOfCarsVariant);
            int randIntForPoints = Random.Range(0, numberOfPointsVariant);
            spawnDetails.spawnOrder.Add(randIntForPoints);
            spawnDetails.carsOrder.Add(randIntForCars);
        }

        Debug.Log("Generated");
    }
}
