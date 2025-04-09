using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour



{
public AudioSource audioSource;
public AudioClip FlagSFX;
private BoxCollider2D boxCollider;
private SoundManager soundManager;



void Awake()
{
    audioSource = GetComponent<AudioSource>();
    boxCollider = GetComponent<BoxCollider2D>();
    soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {

            soundManager.IsFinished = true;
            soundManager.PauseBGM();
            audioSource.PlayOneShot(FlagSFX);
        }
    }
}
