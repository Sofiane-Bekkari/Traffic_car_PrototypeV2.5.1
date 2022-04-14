using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public Toggle soundFx;
    [SerializeField] public int soundFxIsOn = 1;
    public AudioSource[] effectSounds; 
    public AudioSource backgroundSounds; 


    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume") && !PlayerPrefs.HasKey("soundFxs"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            PlayerPrefs.SetInt("soundFxs", 1);
            Load();
          
        }
        else
        {
            Load();
        }
    }

    // CHANGE VOLUME
    public void ChangeVolume()
    {
        backgroundSounds.volume = volumeSlider.value;
        Save();
    }

    // TOGGLE
    public void ToggleSoundFx()
    {
        
        if (!soundFx.isOn)
        {
            soundFxIsOn = 0;
            for (int i = 0; i < effectSounds.Length; i++)
            {
                effectSounds[i].volume = 0f;
                Save();
            }

        }
        if (soundFx.isOn)
        {
            soundFxIsOn = 1;
            for (int i = 0; i < effectSounds.Length; i++)
            {
                effectSounds[i].volume = 1f;
                Save();
               
            }

        }
    }
    // SAVE
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);  
        PlayerPrefs.SetInt("soundFxs", (soundFx.isOn ? 1 : 0));
        //Debug.Log("SoundFX On Save: " + soundFx.isOn);
    }
    // LOAD
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundFx.isOn = (PlayerPrefs.GetInt("soundFxs") != 0);
        //Debug.Log("SoundFX On LOAD: " + soundFx.isOn);
    }

}
