using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    private Animator animator;

    private AudioSource audioSource;

    public AudioClip MisteryBoxSFX;
    public AudioClip MisteryBoxSFXOpen;
    public Transform mushroomSpawn;
    public GameObject mushroomPrefab;
    public AudioClip mushroomSFX;
    private bool isOpened = false;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void ActivateBox()
     {

        if(!isOpened)
        {
            animator.SetTrigger("IsUsed");
            audioSource.clip = MisteryBoxSFX;
            Instantiate(mushroomPrefab, mushroomSpawn.position, mushroomSpawn.rotation);
            isOpened = true;
        }
        else
        {
            audioSource.clip = MisteryBoxSFXOpen;
        }
        audioSource.Play();
     }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ActivateBox();
        }
    }

}