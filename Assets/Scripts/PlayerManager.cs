using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Animator playerAnimator;
    public static float health = 100;
    public float money;
    public float bulletSpeed = 1f;
    private bool dead = false;
    private bool canShoot = true;
    public GameObject ReplayButton;
    public AudioSource takeDamageSound;
    public AudioSource shirukenSound;

    public AudioSource dieSound;

    // Start is called before the first frame update
    public Text moneyText;
    public Slider slider;
    Transform muzzle;
    public Transform bullet, floatingText;

    private PlayerController _playerController;


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        muzzle = transform.GetChild(1);
        slider.maxValue = health;

        moneyText.text = "x " + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        playerAnimator.SetFloat("playerHealth", health);
        if (Input.GetKeyDown("space"))
        {
            ShootBullet();
        }
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
            Destroy(gameObject);
            Time.timeScale = 0;
            ReplayButton.SetActive(true);
        }

        slider.value = health;

        AmIDead();
    }

    public void DestroyPlayer()
    {
        dieSound.Play();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        health = 0;
        Destroy(gameObject, 1);
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