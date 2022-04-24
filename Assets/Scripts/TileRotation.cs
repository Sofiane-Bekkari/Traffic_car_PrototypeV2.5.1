using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotation : MonoBehaviour
{
    private AudioSource tileSound;
    public PauseMenu pausedIsOn;
    public bool CountClick = false;
    private void Start()
    {
        tileSound = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        if (Time.timeScale == 1) // IF THE GAME IS NOT ON PAUSE
        {
            transform.Rotate(0, 0, -90f);
            tileSound.Play();
            CountClick = true;
            //FindObjectOfType<CountClickOnTile>().CounterClick(CountClick);

           
        }
    }
}
