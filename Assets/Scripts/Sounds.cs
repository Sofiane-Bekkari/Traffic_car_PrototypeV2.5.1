using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // MAKE IT SERIALIZABLE
public class Sounds // TYPE OF DATA
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    //[HideInInspector]
    public AudioSource source;
    
}
