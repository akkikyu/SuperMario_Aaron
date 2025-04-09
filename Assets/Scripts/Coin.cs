using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private CircleCollider2D circleCollider;
    private AudioSource audioSource;
    public AudioClip CoinSFX;
    private SpriteRenderer renderer;
    GameManager gameManager;
    


    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //Como buscar un void de otro script
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
           
            Interact();
        }
    }


    void Interact()
    {
    
        gameManager.AddCoins();
        circleCollider.enabled = false;
        renderer.enabled = false;
        audioSource.PlayOneShot(CoinSFX);
        Destroy(gameObject, 0.3f);
    }

}