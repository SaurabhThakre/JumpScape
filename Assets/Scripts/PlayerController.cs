using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveX;
    public bool isMoving;
    public float forceX;
    public float impulseY;
    public bool isOnGround = false;
    public bool lastOnGround;
    public bool landedOnGround;
    public bool isJumpKeyPressed;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip shootSound;

    public string direction;

    public Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        animator.SetFloat(PAP.moveX, moveX);

        isMoving = !Mathf.Approximately(moveX, 0f);
        animator.SetBool(PAP.isMoving, isMoving);

        CheckPlayerOnGroundAndLanding();

        PlayerJump();

        ShootBullet();

    }

    private void FixedUpdate()
    {
        forceX = animator.GetFloat(PAP.forceX);

        if (forceX != 0)
        {
            rb.AddForce(new Vector2(forceX, 0) * Time.deltaTime);
        }

        impulseY = animator.GetFloat(PAP.impulseY);

        if(impulseY != 0)
        {
            rb.AddForce(new Vector2(0, impulseY), ForceMode2D.Impulse);
            animator.SetFloat(PAP.impulseY, 0);
        }

        animator.SetFloat(PAP.velocityY, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    public void CheckPlayerOnGroundAndLanding()
    {
        // Check & Trigger for On Ground
        lastOnGround = animator.GetBool(PAP.isOnGround);
        animator.SetBool(PAP.isOnGround, isOnGround);

        // Set the condition that the player has reached the ground and can enter a landing state
        if (lastOnGround == false && isOnGround == true)
        {
            animator.SetTrigger(PAP.landedOnGround);
        }
    }

    public void PlayerJump()
    {
        isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);

        if (isJumpKeyPressed)
        {
            animator.SetTrigger(PAP.jumpTriggerName);
            playerAudio.PlayOneShot(jumpSound, 1);
        }
        else
        {
            animator.ResetTrigger(PAP.jumpTriggerName);
        }
    }

    public void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Get an object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                playerAudio.PlayOneShot(shootSound);
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
                pooledProjectile.transform.rotation = transform.rotation;
            }
        }
    }

}
