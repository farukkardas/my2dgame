using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        SceneManager.LoadScene("InGame");

    }

    public void PlayButton()
    {
        inGameScreen.SetActive(true); 
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }


}
