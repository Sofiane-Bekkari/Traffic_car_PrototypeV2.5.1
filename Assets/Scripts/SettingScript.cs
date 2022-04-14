using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingScript : MonoBehaviour
{
   
    public AudioMixer mainVolume;

    void Update()
    {
       
    }
    public void SetVomule(float volume)
    {
        //Nvolume = volume;
        mainVolume.SetFloat("Volume2", volume);
      
    }

}
