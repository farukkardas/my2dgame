using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
  
    void Start()
    {
      
    }

    //// Refactor edilip levelscore fonksiyonu bu method üzerinden çağırılacak
    
    // public void FirstLevelScore()
    // {
    //     if (Time.timeSinceLevelLoad <= 40 && PlayerManager.money >= 5 || Time.timeSinceLevelLoad <= 40 ||
    //         PlayerManager.money >= 5)
    //     {
    //         EndLevelScript.instance.scoreText.enabled = true;
    //         EndLevelScript.instance.scoreText.text = "Level completed. You earned 3 star";
    //     }
    //
    //     else if (Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 && PlayerManager.money >= 3 ||
    //              Time.timeSinceLevelLoad >= 40 && Time.timeSinceLevelLoad <= 60 ||
    //              PlayerManager.money >= 3 && PlayerManager.money < 5)
    //     {
    //         EndLevelScript.instance.scoreText.enabled = true;
    //         EndLevelScript.instance.scoreText.text = "Level Completed. You earned 2 star";
    //     }
    //
    //     else
    //     {
    //         EndLevelScript.instance.scoreText.enabled = true;
    //         EndLevelScript.instance.scoreText.text = "Level Completed. You earned 1 star";
    //     }
    // }
}