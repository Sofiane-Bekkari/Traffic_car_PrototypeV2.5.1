using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] car;
	public SpawnDetails spawnDetails;
	public float firstSpawn = 0f;
	public float spawnRate = 5f;
	public static int numberOfCars; //used for ui and other script
	int[] carsOrder ;
	int[] pointsOrder ;
	bool spawnAllowed;
	int i = 0;

	private void Awake()
    {
		numberOfCars = spawnDetails.totalCarsNumber;
		carsOrder = spawnDetails.carsOrder.ToArray();
		pointsOrder = spawnDetails.spawnOrder.ToArray();
	}
    void Start()
	{
		spawnAllowed = true;
		InvokeRepeating("SpawnCar", firstSpawn, spawnRate);
	}

	void SpawnCar()
	{
		if(spawnAllowed)
        {
			int CurrentCarToSpawn = carsOrder[i];
			int CurrentSpawnPoint = pointsOrder[i];

			Instantiate(car[CurrentCarToSpawn], spawnPoints[CurrentSpawnPoint].position, spawnPoints[CurrentSpawnPoint].rotation);
			StartCoroutine(FlashAlertIcon(spawnPoints[CurrentSpawnPoint]));

			i++;
			if(i == numberOfCars)
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
