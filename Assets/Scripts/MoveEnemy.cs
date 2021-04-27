using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;
    public float firstPos;
    public float secondPos;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
        if(transform.position.x >= firstPos) {
            dirRight = false;
        }
         
        if(transform.position.x <= secondPos) {
            dirRight = true;
        }
      
    }

   
}
