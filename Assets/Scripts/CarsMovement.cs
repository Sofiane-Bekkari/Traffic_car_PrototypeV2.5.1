using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    public float moveSpeed, delayRotation;
    public AudioClip goalReached , carCrash;
    GameManager gameManager;
    AudioSource carSound;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        carSound = GetComponent<AudioSource>();
    }

    void Update()
    {  
       transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car")) 
        {
            carSound.PlayOneShot(carCrash);
            gameManager.LosingEvent(); 
        }

        if (collision.gameObject.CompareTag("Station"))
        {
            carSound.PlayOneShot(goalReached); 
            gameObject.GetComponent<SpriteRenderer>().enabled = false; // Disable Sprite before DESTROY IT
            Destroy(gameObject, 1f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Tile"))
        {
            StartCoroutine(delayOnTurn(collision.transform.rotation));
        }

        if (collision.gameObject.CompareTag("Boundaries") &&
           transform.position.x > -16f && transform.position.x < 16f &&
           transform.position.y > -8f && transform.position.y < 8f)
        {
            gameManager.LosingEvent();
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            string arrowColor = GetColor(collision.gameObject);
            string carColor = GetColor(this.gameObject);

            if (arrowColor == carColor)
                StartCoroutine(delayOnTurn(collision.transform.rotation));
        }
    }
    string GetColor(GameObject gameObject)
    {
        string name = gameObject.name;
        return name.Substring(0, name.IndexOf('_'));
    }

    IEnumerator delayOnTurn(Quaternion direction)
    {
        yield return new WaitForSeconds(delayRotation);
        transform.rotation = direction;
    }
}
