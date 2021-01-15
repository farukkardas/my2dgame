using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public void PlayButton()
    {
        inGameScreen.SetActive(true); 
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void HomeButton()
    {

    }


}
