using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] car;
	bool spawnAllowed;
	public float firstSpawn = 0f;
	public float spawnRate = 5f;
	public int numberOfCarsToSpawn = 4;
	public static int numberOfCars; //a clone of numberOfCarsToSpawn that will not dicrement-- to access the initial value of numberOfCarsToSpawn in other script

    private void Awake()
    {
		numberOfCars = numberOfCarsToSpawn;
	}
    void Start()
	{
		spawnAllowed = true;
		InvokeRepeating("SpawnCar", firstSpawn, spawnRate);
	}

	void SpawnCar()
	{
		if (spawnAllowed)
		{
			int randIntForCars = Random.Range(0, car.Length);
			int randIntForPoints = Random.Range(0, spawnPoints.Length);
			
			Instantiate(car[randIntForCars], spawnPoints[randIntForPoints].position, spawnPoints[randIntForPoints].rotation);
			StartCoroutine(FlashAlertIcon(spawnPoints[randIntForPoints]));

			numberOfCarsToSpawn--; 
			if(numberOfCarsToSpawn == 0)
            {
				spawnAllowed = false;
			}
		}
	}

	IEnumerator FlashAlertIcon(Transform parentTransform)
	{
		GameObject alertIcon = parentTransform.GetChild(0).gameObject;
		
			alertIcon.SetActive(true);
			yield return new WaitForSeconds(0.4f);
			alertIcon.SetActive(false);
			yield return new WaitForSeconds(0.4f);
			alertIcon.SetActive(true);
			yield return new WaitForSeconds(0.4f);
			alertIcon.SetActive(false);
	}

}
