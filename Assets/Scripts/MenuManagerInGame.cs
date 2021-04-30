using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    bool isSound = false;
    
    void Start()
    {
    }

    
    void Update()
    {
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void SoundController()
    {
        if (!isSound)
        {
            AudioListener.pause = true;
            isSound = true;
        }
        else
        {
            AudioListener.pause = false;
            isSound = false;
        }
    }
}