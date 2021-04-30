using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerController : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    bool facingRight = true;
    public float jumpDelay = 1.0f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextjumpTime, jumpAudioFreq = 1f, nextAudioFreq;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public AudioSource jumpAudio;
    public static float health;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;
    private bool moveLeft;
    private bool dontMove;
    private bool canJump = true;


    void Awake()
    {
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        dontMove = true;
    }

    void Update()
    {
        health = PlayerManager.health;
        OnGroundCheck();
        FlipFaceCondition();
        HandleMoving();
    }


    private void HandleMoving()
    {
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
        if (dontMove)
        {
            StopMoving();
        }
        else
        {
            if (moveLeft)
            {
                MoveLeft();
            }
            else if (!moveLeft)
            {
                MoveRight();
            }
        }
    }

    // CanDoJump methodu yerine bu da tercih edilebilir. Zemine basıp basmadığını kontrol edip ona göre karakter zıplayabiliyor.
    
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.layer == 8)
    //     {
    //         canJump = true;
    //     }
    // }
    //
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.layer == 8)
    //     {
    //         canJump = false;
    //         isGrounded = false;
    //     }
    // }

    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveLeft = movement;
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }

    private void MoveRight()
    {
        playerRB.velocity = new Vector2(-moveSpeed, playerRB.velocity.y);
    }

    private void MoveLeft()
    {
        playerRB.velocity = new Vector2(moveSpeed, playerRB.velocity.y);
    }

    private void StopMoving()
    {
        playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
    }

    private void FlipFaceCondition()
    {
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }

        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }


    void FlipFace()
    {
        if (health >= 1)
        {
            facingRight = !facingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }
    }

    public void Jump()
    {
        if (isGrounded && canJump)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpSpeed);
            jumpAudio.Play();
            // StartCoroutine(CanDoJump());
        }
    }
    
    // Bu method karaktere knocback uyguluyor.
    public void ThrowPlayer()
    {
        playerRB.AddForce(new Vector2(-2000f, 180f));
    }

    //Karakterin zeminde olup olmadığını kontrol ediyor.
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedJump", isGrounded);
    }
    
    // Aslında isgrounded zeminde olup olmadığını kontrol ediyor fakat ben yine de manuel olarak zıplamaya delay ekledim.
    private IEnumerator CanDoJump()
    {
        canJump = false;
        yield return new WaitForSeconds(0.6f);
        canJump = true;
    }
}