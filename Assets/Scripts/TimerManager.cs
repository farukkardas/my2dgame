using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // startTime.text = Time.time.ToString("N0");
        startTime.text = "" +  Time.timeSinceLevelLoad.ToString("N0");
        startTime.enabled = true;

       
    }
}
