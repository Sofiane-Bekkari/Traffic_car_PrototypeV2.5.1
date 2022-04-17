using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public static SoundManager Instance; // WHOLE SOUNDMANAGER INSTANCE
    public Toggle _toggle; // TOGGLE UI
    [SerializeField] Slider _slider; // SLIDER UI
    //[SerializeField] public AudioSource _musicSource; // BACKGROUND MUSIC


    void Awake() // BEFORE EVERYTHING
    {

        int isToggle = PlayerPrefs.GetInt("ToggleBool"); // GET VALUE FOR TOGGLE
        float vol = PlayerPrefs.GetFloat("musicVolume"); // GET VALUE FOR SILDER

        LoadValue(isToggle); // INITIALIZE UI TOGGLE BOOL 
        ChangeMusicVolume(vol); // INITIALIZE UI SLIDER VOLUME
    }

    // GET ALL SFX ON/OFF
    public void SoundMuteOnOff()
    {
       
            if (!_toggle.isOn) // IF TOGGLE IS NOT ON
            {
              
                UpdateValue(); // SAVE VALUE
            }
            else
            {
         
                UpdateValue();// SAVE VALUE
            }
      
    }
    void LoadValue(int isToggle) // SET VALUE FOR ON LOAD 
    {
        if (isToggle == 0) // GET VALUE FORM PLAYERPREF AS INT 0/1
        {
            _toggle.isOn = false; // VALUE 0
        }
        else
        {
            _toggle.isOn = true; // VALUE 1
        }
        //Debug.Log("Loading... " + _toggle.isOn);
    }

    public void UpdateValue() // KEEP TRACK FOR TOGGLE STATE
    {
        if (_toggle.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleBool", 1); // STORE AS 1
            PlayerPrefs.Save(); // SAVE
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool", 0); // STORE AS 0
            PlayerPrefs.Save(); // SAVE
        }
    }
    // MASTER VOLUME
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }


    // BACKGROUND MUSIC VOLUME 
    public void ChangeMusicVolume(float value) // GET VALUE FROM SLIDER
    {

        AudioManager.instance.ChangeMusicVolume(value, _slider); // this if it works MAGIC
        //_musicSource.volume = value; // SET FOR CURRENT VOLUME
        //_slider.value = value; // new line code
        _slider.value = value; // SET IT FOR SLIDER ON LOAD
        PlayerPrefs.SetFloat("musicVolume", value); // STORE IT 
        PlayerPrefs.Save(); // SAVE IT
    }
    // CHANGE VOLUME IN SOME CASES
    public void ChangeVolumeInCase(float value)
    {
        //_musicSource.volume = value; // SET FOR CURRENT VOLUME
    }
    // CHANGING PITCH FOR MUSIC
    public void ChangePitchMusic(float pitch)
    {
        //_musicSource.pitch = pitch;
    }
}