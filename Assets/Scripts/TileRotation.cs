using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotation : MonoBehaviour
{
    private AudioSource tileSound;
    private void Start()
    {
        tileSound = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
      transform.Rotate(0, 0, -90f);
      tileSound.Play();
    }
}
