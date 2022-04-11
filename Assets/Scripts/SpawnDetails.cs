using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LvL", menuName = "SpawnData")]
public class SpawnDetails : ScriptableObject
{
    public int totalCarsNumber;
    public List<int> carsOrder = new List<int>();
    public List<int> spawnOrder = new List<int>();
}
