﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float health;
    bool dead = false;
    public float bulletSpeed = 1f;

    Transform muzzle;
    public Transform bullet,floatingText;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }
    public void GetDamage(float damage)
    {

        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text =damage.ToString();  
        if ((health - damage) >=0) 
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }

     void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward  * bulletSpeed);      
    }

}
