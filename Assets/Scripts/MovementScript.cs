using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public GameObject audioSource;
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public float doubleJumpPower = 12f;
    private bool isFacingRight = true;

    private bool doubleJump;

    private bool isWallSliding;
    public float wallSlideSpeed = 16f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    public float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    public float wallJumpingDuration = 0.4f;
    public float wallPowerX;
    public float wallPowerY;
    private Vector2 wallJumpingPower = new Vector2(0f, 0f);

    private BoxCollider2D coll;

    private Vector3 platformOffset;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Animator anim;

    private void Start()
    {
       wallJumpingPower = new Vector2(wallPowerX, wallPowerY);
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isWallJumping)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal > 0f || horizontal < 0f)
            {
                anim.SetBool("isRunning", true);
                gameObject.transform.SetParent(null);
            }
            else if (horizontal == 0f)
            {
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            horizontal = 0f;
            anim.SetBool("isRunning", false);
        }

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (!IsGrounded())
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

        if (Input.GetButtonDown("Jump"))
        {

            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpPower : jumpingPower);

                doubleJump = !doubleJump;

                anim.SetTrigger("JumpTrigger");

                gameObject.transform.SetParent(null);
                audioSource.GetComponent<scr_soundEffects>().playSound(audioSource.GetComponent<scr_soundEffects>().sfJump);
            }
       
        }
        
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallSlide();
        WallJump();
        
        if (!isWallJumping)
        {
            Flip();
        }

        transform.position = new Vector3(transform.position.x + platformOffset.x, transform.position.y, transform.position.z);

    }
    private void FixedUpdate()
    {
        if(!isWallJumping)
        {
           rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private bool isWalled()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, 0.1f, wallLayer);
    }

    private void WallSlide()
    {
        if (isWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;

            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
        doubleJump = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalPlatform"))
        {
            // Calculate the initial offset when the player lands on the platform
            platformOffset = transform.position - collision.transform.position;

            // Set the platform as the parent of the player
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalPlatform"))
        {
            // Reset the player's parent when leaving the platform
            transform.parent = null;
        }
    }

}
