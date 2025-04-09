using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool isPaused = false;
    private SoundManager soundManager;
    public GameObject pauseCanvas;
    private int coinCounter = 0; 
    public Text CoinText;
    private int goombaCounter = 0;
    public Text GoombaText;
    void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }
   
    void Start()
    {
        CoinText.text = "Coins: " + coinCounter.ToString();
        GoombaText.text = "Kills: " + goombaCounter.ToString();
    }
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }               
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            soundManager.PauseBGM();
            pauseCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            soundManager.PauseBGM();
            pauseCanvas.SetActive(true);
        }
    }

    public void AddCoins()
    {
        coinCounter++;
        CoinText.text = "Coins: " + coinCounter.ToString();
    }
    public void AddKills()
    {
        goombaCounter++;
        GoombaText.text = "Kills: " + goombaCounter.ToString();
    }
}
