using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPU : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public int direction = 1;
    public float speed = 3;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;
    public AudioClip powerUpSFX;
    private SpriteRenderer renderer;
    


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
 
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(direction * speed, rigidBody.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberia"))
        {
            direction *= -1;
        }
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Mario playerScript = collision.gameObject.GetComponent<Mario>();
            playerScript.canShoot = true;
            playerScript.powerUpTimer = 0;
            Interact();
        }
    }

    void Interact()
    {
        direction = 0;
        rigidBody.gravityScale = 0;
        boxCollider.enabled = false;
        renderer.enabled = false;
        audioSource.PlayOneShot(powerUpSFX);
        Destroy(gameObject, 2f);
    }

}
