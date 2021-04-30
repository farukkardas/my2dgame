using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public Text diedScore;
    public Text starScore;
    private bool canCalculate = true;

    void Start()
    {
    }

    private void Update()
    {
        CanCalculateScore();
        FirstLevelScore();
        FirstLevelStar();
    }
    

    private void FirstLevelScore()
    {
        if (canCalculate)
        {
            score = PlayerManager.money * 400;
            score = score / Time.timeSinceLevelLoad;
            diedScore.text = score.ToString("N0");

            if (score < 0)
            {
                score++;
            }
        }
    }
    
    public void FirstLevelStar()
    {
        if (canCalculate)
        {
            if (Time.timeSinceLevelLoad <= 40 && PlayerManager.money >= 5 || Time.timeSinceLevelLoad <= 40 ||
                PlayerManager.money >= 5)
            {
                starScore.enabled = true;
                starScore.text = "3 STAR";
            }

            else if (Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 && PlayerManager.money >= 3 ||
                     Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 ||
                     PlayerManager.money >= 3 && PlayerManager.money < 5)
            {
                starScore.enabled = true;
                starScore.text = "2 STAR";
            }

            else
            {
                starScore.enabled = true;
                starScore.text = "1 STAR";
            }
        }
    }


    public void CanCalculateScore()
    {
        if (PlayerManager.health < 1)
        {
            canCalculate = false;
        }
    }
}