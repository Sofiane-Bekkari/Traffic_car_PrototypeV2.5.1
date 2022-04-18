using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTutorial : MonoBehaviour
{
    bool isGameStoped = false;
    public GameObject alertMessage;
    float correctRotation = 0f;
    private AudioSource tileSound;

    private void Start()
    {
        tileSound = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        //if ( Time.timeScale == 1) // WHEN GAME IS NOT PAUSE
        //{
            transform.Rotate(0, 0, -90f);
            tileSound.Play();
            if (isGameStoped == true)
            {
                if (transform.rotation.eulerAngles.z == correctRotation)
                {
                    isGameStoped = false;
                    Time.timeScale = 1;
                    alertMessage.SetActive(false);
                }
            }

        //}
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tileName = gameObject.name;
        string carName = collision.name;
        float tileRotation = transform.rotation.eulerAngles.z;

        if (tileName == "TileButtom" && carName == "Blue_Car" && tileRotation != 90)
        {
            isGameStoped = true;
            correctRotation = 90f;
            Time.timeScale = 0;
            alertMessage.SetActive(true);
        }
        if (tileName == "TileTop" && carName == "Blue_Car" && tileRotation != 0)
        {
            isGameStoped = true;
            correctRotation = 0f;
            Time.timeScale = 0;
            alertMessage.SetActive(true);
        }
        if (tileName == "TileTop" && carName == "Red_Car" && tileRotation != 270f)
        {
            isGameStoped = true;
            correctRotation = 270f;
            Time.timeScale = 0;
            alertMessage.SetActive(true);
            Debug.Log(tileRotation);
        }
        if (tileName == "TileButtom" && carName == "Red_Car" && tileRotation != 0)
        {
            isGameStoped = true;
            correctRotation = 0f;
            Time.timeScale = 0;
            alertMessage.SetActive(true);
        }



    }

}
