using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // WHOLE SOUNDMANAGER INSTANCE
    public Toggle _toggle; // TOGGLE UI
    public Slider _slider; // SLIDER UI
    [SerializeField] public AudioSource _musicSource; // BACKGROUND MUSIC
    [SerializeField] public AudioSource[] _effectSource; // LIST SFX

    void Awake() // BEFORE EVERYTHING
    {
        if(Instance == null) // IF NO INSTANCE ON SCENE
        {
            Instance = this; // MAKE THIS AN INSTENCE 
            DontDestroyOnLoad(gameObject); // NOT DESTROY ON LOAD A NEW SCENE
        }
        else
        {
            Destroy(gameObject); // KILL THIS INSTANCE
        }

        int isToggle = PlayerPrefs.GetInt("ToggleBool"); // GET VALUE FOR TOGGLE
        float vol = PlayerPrefs.GetFloat("musicVolume"); // GET VALUE FOR SILDER

        LoadValue(isToggle); // INITIALIZE UI TOGGLE BOOL 
        ChangeMusicVolume(vol); // INITIALIZE UI SLIDER VOLUME
    }

    // GET ALL SFX ON/OFF
    public void SoundMuteOnOff()
    {
        for(int i = 0; i < _effectSource.Length; i++) // TRY TO GET ALL SFX
        {
            if (!_toggle.isOn) // IF TOGGLE IS NOT ON
            {
                _effectSource[i].mute = true; // MUTE
                UpdateValue(); // SAVE VALUE
            }
            else
            {
                _effectSource[i].mute = false; // UNMUTE
                UpdateValue();// SAVE VALUE
            }
        }
    }
    void LoadValue(int isToggle) // SET VALUE FOR ON LOAD 
    {
        if ( isToggle == 0) // GET VALUE FORM PLAYERPREF AS INT 0/1
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
        _musicSource.volume = value; // SET FOR CURRENT VOLUME
        _slider.value = value; // SET IT FOR SLIDER ON LOAD
        PlayerPrefs.SetFloat("musicVolume", value); // STORE IT 
        PlayerPrefs.Save(); // SAVE IT
    }
}