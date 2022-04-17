using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds; // MAKE A LIST OF SOUNDS
    [SerializeField] public AudioSource _musicSource; // BACKGROUND MUSIC
    public static AudioManager instance;

    
    void Awake()
    {
        if( instance == null)
        {
            instance = this;
            Debug.Log("INITIALIZ INSTANCE");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("THERE AN INSTANCE");
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
        }
        
    }

   
    void Start()
    {
        //Play("Theme");
       
    }
    public void ChangeMusicVolume(float value, Slider _slider) // GET VALUE FROM SLIDER
    {
        _musicSource.volume = value; // SET FOR CURRENT VOLUME
        //_slider.value = value; // new line code
        _slider.value = value; // SET IT FOR SLIDER ON LOAD
        PlayerPrefs.SetFloat("musicVolume", value); // STORE IT 
        PlayerPrefs.Save(); // SAVE IT
    }

    // CHANGE VOLUME IN SOME CASES
    public void ChangeVolumeInCase(float value)
    {
        _musicSource.volume = value; // SET FOR CURRENT VOLUME
    }
    // CHANGING PITCH FOR MUSIC
    public void ChangePitchMusic(float pitch)
    {
        _musicSource.pitch = pitch;
    }

    // PLAY SOUNDS
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) // IN CASE OF NONE 
        {
            Debug.LogWarning("Sound: " + name + " Not found!");
            return;
        }
        s.source.Play();
        s.source.volume = 0.5f;
        s.source.pitch = s.pitch;
    }
  
}
