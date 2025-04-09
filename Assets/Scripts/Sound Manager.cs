using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip bgm;
    public AudioClip gameOver;
    public float delay = 0.5f; //CRONOMETRO
    public float timer; //CRONOMETRO

    private GameManager gameManager;

    private bool timerFinished = false;
    public bool IsFinished = false;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!gameManager.isPlaying && !timerFinished)
        {
            DeathBGM();  
        }*/ 
    }

    void PlayBGM()
    {
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }


    public void PauseBGM()
    {
        if(gameManager.isPaused || IsFinished)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    /*public void DeathBGM()
    {
        audioSource.Stop();
        timer += Time.deltaTime; //Como el deltatime calcula el tiempo entre un frame y otro, el TIMER irá sumando el tiempo  //CRONOMETRO
        if(timer >= delay)
        {
            timerFinished = true;
            audioSource.PlayOneShot(gameOver);
        }
    }*/

    /*public IEnumerator DeathBGM()
    {
        
        //audioSource.Stop();
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("suena?");
        //audioSource.PlayOneShot(gameOver);
        audioSource.clip = gameOver;
        //audioSource.loop = false;
        audioSource.Play();

    }*/

    public void DeathBGM()
    {
        audioSource.volume = 1;
        audioSource.clip = gameOver;
        audioSource.loop = false;
        audioSource.Play();
    }


    
}
