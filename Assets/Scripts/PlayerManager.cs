using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Animator playerAnimator;
    public Animation donmeAnimasyonu;
    public static float health = 100;
    public static float money;
    public float bulletSpeed = 1f;
    private bool dead = false;
    private bool canShoot = true;
    public GameObject ReplayButton;
    public AudioSource takeDamageSound;
    public AudioSource shirukenSound;
    public AudioSource coinSound;
    public AudioSource dieSound;
    public AudioSource gameOverSound;
    public AudioSource christmasSong;
    
    
    // Start is called before the first frame update
    public Text moneyText;
    public Slider slider;
    Transform muzzle;
    public Transform bullet, floatingText;


     void Awake()
     {
         money = 0;
        health = 100;
        slider.maxValue = health;
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        muzzle = transform.GetChild(1);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            christmasSong.Stop();
        }
        slider.value = health;
        playerAnimator.SetFloat("playerHealth", health);
        if (Input.GetKeyDown("space"))
        {
            ShootBullet();
        }
        moneyText.text = "x " + money.ToString();
    }
    public void GainMoney()
    {
        money++;
        coinSound.Play();
    }

    public void StayGetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text =
            damage.ToString();

        if ((health - damage) >= 0)
        {
            health -= damage;
            takeDamageSound.Play();
        }

        if (health <= 0)
        {
            DestroyPlayer();
        }

        slider.value = health;
        AmIDead();
    }

    public void DestroyPlayer()
    {
        christmasSong.Stop();
        dieSound.Play();
       FreezePlayer();
        health = 0;
        Destroy(gameObject, 0.8f);
        
        gameOverSound.PlayDelayed(1f);
    }

   public void FreezePlayer()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }


    void AmIDead()
    {
        if (health <= 0)
        {
            dieSound.Play();
            dead = true;
            
        }
    }

    void ShootBullet()
    {
        if (canShoot)
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
            shirukenSound.Play();
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }


}