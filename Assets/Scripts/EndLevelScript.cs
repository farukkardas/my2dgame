using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelScript : MonoBehaviour
{
    public AudioSource winSound;
    public Image levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        levelComplete.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        winSound.Play();
        Time.timeScale = 0;
        levelComplete.enabled = true;
    }
}
