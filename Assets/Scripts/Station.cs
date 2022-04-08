using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public ParticleSystem goalReachedparticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        goalReachedparticle.Play();
        FindObjectOfType<ScoreScript>().UpdateScore();

    }
} 
