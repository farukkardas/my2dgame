using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float damage;
    public float health;
    public float bullet;
    bool colliderBusy = false;
    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().StayGetDamage(damage);

        }
        if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);

        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<PlayerManager>().StayGetDamage(damage);

        }
        if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);

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
        AmIDead();
    }



    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
