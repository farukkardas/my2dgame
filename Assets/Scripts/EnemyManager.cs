using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float damageTimeout = 1f;
    private bool canTakeDamage = true;
    public float damage;
    public float health;
    bool colliderBusy = false;
    public Slider slider;
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTakeDamage && other.gameObject.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.gameObject.GetComponent<PlayerManager>().StayGetDamage(damage);
            StartCoroutine(damageTimer());
            StartCoroutine(playerController.ThrowPlayer(0.02f, 350, playerController.transform.position));
        }

        if (other.gameObject.tag == "Bullet")
        {
            GetDamage(other.gameObject.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (canTakeDamage && other.tag == "Player")
        {
           
            other.GetComponent<PlayerManager>().StayGetDamage(damage);
            StartCoroutine(damageTimer());
            StartCoroutine(playerController.ThrowPlayer(0.02f, 5f, playerController.transform.position));


        }
        if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }



    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            
        }
        slider.value = health;
        
        AmIDead();
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }
}
