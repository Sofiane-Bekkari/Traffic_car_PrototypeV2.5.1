using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ControlFX : MonoBehaviour
{
    int isToggle;
    public AudioSource soundfx;
    // Start is called before the first frame update
    void Start()
    {
        soundfx = GetComponent<AudioSource>();
        isToggle = PlayerPrefs.GetInt("ToggleBool"); // GET VALUE FOR TOGGLE
        Debug.Log("THIS IS ON FX with TOGGLE value of: " + isToggle);
    }

    // Update is called once per frame
    void Update()
    {

        if (isToggle == 1)
        {
            soundfx.mute = false;
        }
        else
        {
            soundfx.mute = true;

        }
      
    }
}
