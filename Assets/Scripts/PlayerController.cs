using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    bool facingRight = true;
    private bool canJump = true;
    public float jumpDelay = 1.0f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextjumpTime, jumpAudioFreq = 1f, nextAudioFreq;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public AudioSource jumpAudio;

    void Awake()
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        


        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }

        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && canJump && (nextjumpTime < Time.timeSinceLevelLoad))
        {
            nextAudioFreq = Time.timeSinceLevelLoad + jumpAudioFreq;
            nextjumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
            StartCoroutine(JumpDelay());
        }

        if (Input.GetKeyDown("h"))
        {
            ThrowPlayer(0.02f, 350, transform.position);
        }
    }

    void FixedUpdate()
    {
       
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
        jumpAudio.Play();
    }

   public IEnumerator ThrowPlayer(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            playerRB.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedJump", isGrounded);
    }
    
    private IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpDelay);
        canJump = true;
    }

  
}
