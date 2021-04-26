using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelScript : MonoBehaviour
{
   
    [SerializeField] private AudioSource winSound;
    public Text scoreText;
    public Button nextLevelButton;
    public Button replayButton;
    void Start()
    {
    }

    private void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CompleteLevel();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        PlaySound();
        FirstLevelScore();
        nextLevelButton.image.enabled = true;
        replayButton.image.enabled = true;
    }


    void PlaySound()
    {
        winSound.Play();
        Destroy(winSound, 4f);
    }


    public void NextLevel()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(2);
    }

    // Bu kod refactor edilip ScoreManager üzerinden daha sonra çekilecek
    public void FirstLevelScore()
    {
        if (Time.timeSinceLevelLoad <= 40 && PlayerManager.money >= 5 || Time.timeSinceLevelLoad <= 40 ||
            PlayerManager.money >= 5)
        {
            scoreText.enabled = true;
            scoreText.text = "Level completed. You earned 3 star";
        }

        else if (Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 && PlayerManager.money >= 3 ||
                 Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 ||
                 PlayerManager.money >= 3 && PlayerManager.money < 5)
        {
            scoreText.enabled = true;
            scoreText.text = "Level Completed. You earned 2 star";
        }

        else
        {
            scoreText.enabled = true;
            scoreText.text = "Level Completed. You earned 1 star";
        }
    }
}